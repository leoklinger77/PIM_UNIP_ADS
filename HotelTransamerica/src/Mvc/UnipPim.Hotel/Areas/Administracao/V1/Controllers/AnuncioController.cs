using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
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
    [ClaimsAuthorize("Anuncio", "Home")]
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
            return View(await MapearAnuncioViewModelAsync(new AnuncioViewModel()));
        }

        [HttpPost("novo-anuncio")]
        public async Task<IActionResult> NovoAnuncio(AnuncioViewModel viewModel)
        {
            if (!ModelState.IsValid) return View(viewModel);

            var foto = CriaAnuncio(viewModel);

            await _anuncioServico.Insert(foto);

            if (OperacaoValida())
            {

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet("editar-anuncio")]
        public async Task<IActionResult> EditarAnuncio(Guid id)
        {
            return View();
        }

        [HttpPost("editar-anuncio")]
        public async Task<IActionResult> EditarAnuncio(Guid id, AnuncioViewModel viewModel)
        {
            return View();
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

        private Anuncio CriaAnuncio(AnuncioViewModel viewModel)
        {
            var list = Request.Form["imagem"];
            string[] fotos = list.ToString().Split(',');
            var anuncio = new Anuncio(viewModel.Nome, viewModel.Ativo, viewModel.Quantidade, viewModel.Custo, _user.UserId, viewModel.QuartoId);
            foreach (var item in fotos)
            {
                var caminho = item.Split('/');
                anuncio.AddFoto(new Foto(caminho[3]));
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

        private async Task<AnuncioViewModel> MapearAnuncioViewModelAsync(AnuncioViewModel viewModel)
        {
            viewModel.ListaQuarto = _mapper.Map<IEnumerable<QuartoViewModel>>(await _anuncioServico.ListarQuartosDisponiveis());
            return viewModel;
        }
    }
}
