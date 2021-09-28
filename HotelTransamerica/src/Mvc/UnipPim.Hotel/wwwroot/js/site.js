$(document).ready(function () {
    $("#msg_box").fadeOut(2500);
    AjaxUploadImageProduto();
});


function BuscaCep() {
    $(document).ready(function () {

        function limpa_formulário_cep() {

            $("#Endereco_Logradouro").val("");
            $("#Endereco_Bairro").val("");
            $("#Endereco_Cidade").val("");
            $("#Endereco_Estado").val("");
        }

        $("#Endereco_Cep").blur(function () {
            var cep = $(this).val().replace(/\D/g, '');
            if (cep != "") {
                var validacep = /^[0-9]{8}$/;
                if (validacep.test(cep)) {

                    $("#Endereco_Logradouro").val("...");
                    $("#Endereco_Bairro").val("...");
                    $("#Endereco_Cidade").val("...");
                    $("#Endereco_Estado").val("...");

                    $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

                        if (!("erro" in dados)) {

                            $("#Endereco_Logradouro").val(dados.logradouro);
                            $("#Endereco_Bairro").val(dados.bairro);
                            $("#Endereco_Cidade").val(dados.localidade);
                            $("#Endereco_Estado").val(dados.uf);
                        }
                        else {

                            limpa_formulário_cep();
                            alert("CEP não encontrado.");
                        }
                    });
                }
                else {

                    limpa_formulário_cep();
                    alert("Formato de CEP inválido.");
                }
            }
            else {

                limpa_formulário_cep();
            }
        });
    });
}



function AjaxUploadImageProduto() {
    $('.img-upload').click(function () {
        $(this).parent().find('.input-file').click();
    });

    $('.input-file').change(function () {
        var file = new FormData();
        file.append('file', $(this)[0].files[0]);

        var campoHidden = $(this).parent().find('input[name=imagem]');
        var caminho = $(this).parent().find('.img-upload');

        $.ajax({
            type: "POST",
            url: "/Administracao/Anuncio/upload-imagem",
            data: file,
            contentType: false,
            processData: false,
            error: function () {
                alert("Erro ao enviar foto");
            },
            success: function (data) {
                caminho.attr("src", data);
                campoHidden.val(data);

            }
        });
    });

    $('.btn-image-excluir').click(function () {
        var path = $(this).parent().find('input[name=imagem]').val().split('/');
        var caminho = path[3];
        var image = $(this).parent().find('.img-upload');
        $.ajax({
            type: "GET",
            url: "/Administracao/Anuncio/Delete-imagem/" + caminho,
            error: function () {

            },
            success: function (data) {
                image.attr("src", "/imagem/img_padrao.png");
                $(this).parent().find('input[name=imagem]').val("");
            }
        })
    });
}


