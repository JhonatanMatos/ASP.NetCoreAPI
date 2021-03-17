using BackAngular.Models;
using BackAngular.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BackAngular.Controllers
{
    [Route("usuarios")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService service;

        public UsuariosController(IUsuarioService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var model = service.GetUsuarios();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpGet("{id}", Name = "GetUsuario")]
        public IActionResult Get(int id)
        {
            var model = service.GetUsuario(id);
            if (model == null)
                return NotFound();

            var outputModel = ToOutputModel(model);
            return Ok(outputModel);
        }

        [HttpPost]
        public IActionResult Create([FromBody]UsuarioInputModel inputModel)
        {
            if (inputModel == null)
                return BadRequest();

            var model = ToDomainModel(inputModel);
            service.AddUsuario(model);

            var outputModel = ToOutputModel(model);
            return CreatedAtRoute("GetUsuario", new { id = outputModel.Id }, outputModel);
        }
        
        private UsuarioOutputModel ToOutputModel(Usuario model)
        {
            return new UsuarioOutputModel
            {
                Id = model.Id,
                Nome = model.Nome,
                Parcelas = model.Parcelas,
                Valor = model.Valor,                
            };
        }

        private List<UsuarioOutputModel> ToOutputModel(List<Usuario> model)
        {
            return model.Select(item => ToOutputModel(item)).ToList();
        }

        private Usuario ToDomainModel(UsuarioInputModel inputModel)
        {
            return new Usuario
            {
                Id = inputModel.Id,
                Nome = inputModel.Nome,
                Parcelas = inputModel.Parcelas,
                Valor = inputModel.Valor
            };
        }

        private UsuarioInputModel ToInputModel(Usuario model)
        {
            return new UsuarioInputModel
            {
                Id = model.Id,
                Nome = model.Nome,
                Parcelas = model.Parcelas,
                Valor = model.Valor
            };
        }
    }
}
