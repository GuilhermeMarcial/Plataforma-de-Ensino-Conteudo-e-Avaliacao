using AutoMapper;
using PlataformaDeEnsino.Core.Entities;
using PlataformaDeEnsino.Presenter.Coordenadores.ViewModels;
using PlataformaDeEnsino.Presenter.Coordenadores.ViewModels.InstituicaoViewModels;
using PlataformaDeEnsino.Presenter.ViewModels.InstituicaoViewModels;

namespace PlataformaDeEnsino.Presenter.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Pessoa, PessoaViewModel>().ReverseMap();
            CreateMap<Aluno, AlunoViewModel>().ReverseMap();
            CreateMap<Aluno, EditarAlunoViewModel>().ReverseMap();
            CreateMap<Coordenador, CoordenadorViewModel>().ReverseMap();
            CreateMap<Curso, CursoViewModel>().ReverseMap();
            CreateMap<Professor, ProfessorViewModel>().ReverseMap();
            CreateMap<Professor, EditarProfessorViewModel>().ReverseMap();
            CreateMap<Modulo, ModuloViewModel>().ReverseMap();
            CreateMap<Unidade, UnidadeViewModel>().ReverseMap();
        }
    }
}