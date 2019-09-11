using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDSTecnologia.Site.Core.Entities;
using X.PagedList;

namespace TDSTecnologia.Site.Web.ViewModels
{
    public class CursoViewModel
    {
        public string Texto { get; set; }

        public IEnumerable<Curso> Cursos { get; set; }

        public IPagedList<Curso> CursosComPaginacao { get; set; }
    }
}
