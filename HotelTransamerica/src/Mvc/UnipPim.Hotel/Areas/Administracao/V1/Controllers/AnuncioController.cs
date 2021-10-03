using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnipPim.Hotel.Controllers;
using UnipPim.Hotel.Dominio.Interfaces;
using UnipPim.Hotel.Dominio.Interfaces.Servicos;
using UnipPim.Hotel.Dominio.Models;
using UnipPim.Hotel.Extensions.Midleware;
using UnipPim.Hotel.Models;

namespace UnipPim.Hotel.Areas.Administracao.V1.Controllers
{
    [Authorize]
    [ClaimsAutorizacao("Anuncio", "Home")]
    [Area("Administracao")]
    [Route("Administracao/[controller]")]
    public class AnuncioController : MainController
    {
        private readonly IAnuncioServico _anuncioServico;

        public AnuncioController(IMapper mapper,
                                    IUser user,
                                    INotificacao notificacao,
                                    IAnuncioServico anuncioServico)
                                    : base(mapper, user, notificacao)
        {
            _anuncioServico = anuncioServico;
        }

        [HttpGet("lista-anuncio")]
        public async Task<IActionResult> Index(int page = 1, int size = 8, string query = null)
        {
            return View(_mapper.Map<PaginacaoViewModel<AnuncioViewModel>>(await _anuncioServico.PaginacaoListaAnuncio(page, size, query)));
        }

        [HttpGet("novo-anuncio")]
        public async Task<IActionResult> NovoAnuncio()
        {
            return View(await MapearAnuncioViewModel(new AnuncioViewModel()));
        }

        [HttpPost("novo-anuncio")]
        public async Task<IActionResult> NovoAnuncio(AnuncioViewModel viewModel)
        {
            viewModel = _mapper.Map<AnuncioViewModel>(ObterFotosDoRequest(viewModel));
            if (!ModelState.IsValid)
            {
                return View(await MapearAnuncioViewModel(viewModel));
            }

            if (viewModel.Fotos.Count() == 0)
            {
                AddErro("Obrigatório inserir 1 foto para cadastrar um anuncio.");
                OperacaoValida();
                return View(await MapearAnuncioViewModel(viewModel)); ;
            }

            await _anuncioServico.Insert(_mapper.Map<Anuncio>(viewModel));

            if (OperacaoValida())
            {

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar-anuncio")]
        public async Task<IActionResult> EditarAnuncio(Guid id)
        {
            var result = await _anuncioServico.ObterPorId(id);

            if (OperacaoValida())
            {
                ErrosTempData();
                return RedirectToAction(nameof(Index));
            }

            return View(await MapearAnuncioViewModel(_mapper.Map<AnuncioViewModel>(result)));
        }

        [HttpPost("editar-anuncio")]
        public async Task<IActionResult> EditarAnuncio(Guid id, AnuncioViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            viewModel = _mapper.Map<AnuncioViewModel>(ObterFotosDoRequest(viewModel));
            if (!ModelState.IsValid)
            {
                return View(await MapearAnuncioViewModel(viewModel));
            }

            if (viewModel.Fotos.Count() == 0)
            {
                AddErro("Obrigatório inserir 1 foto para cadastrar um anuncio.");
                OperacaoValida();
                return View(await MapearAnuncioViewModel(viewModel)); ;
            }

            await _anuncioServico.Update(_mapper.Map<Anuncio>(viewModel));

            if (OperacaoValida())
            {

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("detalhes-anuncio")]
        public async Task<IActionResult> DetalhesAnuncio(Guid id)
        {
            return View();
        }

        [HttpGet("deleta-anuncio")]
        public async Task<IActionResult> DeleteAnuncio(Guid id)
        {
            return View();
        }

        [HttpPost("deleta-anuncio")]
        public async Task<IActionResult> ConfirmaDeleteAnuncio(Guid id)
        {
            return View();
        }

        [HttpPost("upload-imagem")]
        public async Task<ActionResult> UploadImagem([Required] IFormFile file)
        {
            if (!ModelState.IsValid) return BadRequest();

            var caminho = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            if (UpdateImagem(file, caminho))
            {
                return Ok($"/imagem/anuncio/{caminho}");
            }
            return BadRequest();
        }

        [HttpGet("delete-imagem/{caminho}")]
        public async Task<ActionResult> DeleteImagem(string caminho)
        {
            if (RemoveImagem(caminho))
            {
                return Ok();
            }
            return BadRequest();
        }

        private Anuncio ObterFotosDoRequest(AnuncioViewModel viewModel)
        {
            var list = Request.Form["imagem"];
            string[] fotos = list.ToString().Split(',');
            Anuncio anuncio;
            if (viewModel.Id != Guid.Empty)
            {
                anuncio = new Anuncio(viewModel.Id, viewModel.Nome, viewModel.Ativo, viewModel.Quantidade, viewModel.Custo, _user.UserId, viewModel.QuartoId);
            }
            else
            {
                anuncio = new Anuncio(viewModel.Nome, viewModel.Ativo, viewModel.Quantidade, viewModel.Custo, _user.UserId, viewModel.QuartoId);
            }
            
            if (!(fotos[0] == ""))
                foreach (var item in fotos)
                {
                    var caminho = item.Split('/');
                    if (caminho.Count() == 1)
                    {
                        anuncio.AddFoto(new Foto(caminho[0]));
                    }
                    else
                    {
                        anuncio.AddFoto(new Foto(caminho[3]));
                    }
                }
            return anuncio;
        }

        private bool UpdateImagem(IFormFile file, string imgName)
        {
            if (file == null || file.Length == 0)
            {
                AddErro("Forneça uma imagem para este produto!");
                return false;
            }
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagem/anuncio", imgName);
            if (System.IO.File.Exists(filePath))
            {
                AddErro("Já existe um arquivo com esse nome!");
                return false;
            }

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return true;
        }

        private bool RemoveImagem(string imgName)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagem/anuncio", imgName);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                if (System.IO.File.Exists(filePath))
                {
                    AddErro("Erro ao excluir o arquivo.");
                    return false;
                }
                return true;
            }
            else
            {
                AddErro("Arquivo não encontrado!");
                return false;
            }
        }

        private async Task<AnuncioViewModel> MapearAnuncioViewModel(AnuncioViewModel viewModel)
        {
            viewModel.ListaQuarto = _mapper.Map<IEnumerable<QuartoViewModel>>(await _anuncioServico.ListarQuartosDisponiveis());
            return viewModel;
        }
    }
}
