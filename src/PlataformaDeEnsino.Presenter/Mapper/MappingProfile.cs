using AutoMapper;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Presenter.ViewModels;

namespace PlataformaDeEnsino.Presenter.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();
            CreateMap<Coordenador, CoordenadorViewModel>().ReverseMap();
            CreateMap<Curso, CursoViewModel>().ReverseMap();
            CreateMap<Professor, ProfessorViewModel>().ReverseMap();
            CreateMap<Modulo, ModuloViewModel>().ReverseMap();
            CreateMap<Unidade, UnidadeViewModel>().ReverseMap();
        }
    }
}