using EduxProject.Contexts;
using EduxProject.Domains;
using EduxProject.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxProject.Repositories
{
    public class ObjetivoAlunoRepository : IObjetivoAluno
    {
        private readonly EduxContext _contexto;

        public ObjetivoAlunoRepository()
        {
            _contexto = new EduxContext();
        }

        public List<ObjetivoAluno> ListarObjetivosDosAlunos()
        {
            try
            {
                List<ObjetivoAluno> _listaObjetivos = _contexto.ObjetivoAluno.Include("IdAlunoTurmaNavigation")
                                                            .Include("IdObjetivoNavigation").ToList();

                foreach(ObjetivoAluno _objetivo in _listaObjetivos)
                {
                    _objetivo.IdAlunoTurmaNavigation.ObjetivoAluno = null;
                    _objetivo.IdObjetivoNavigation.ObjetivoAluno = null;
                }

                return _listaObjetivos;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public List<ObjetivoAluno> ProcurarAlunosPorObjetivo(int _idObjetivo)
        {
            try
            {
                List<ObjetivoAluno> _listaAlunosObjetivo = _contexto.ObjetivoAluno
                                                        .Where(oba => oba.IdObjetivo == _idObjetivo)
                                                        .Include("IdAlunoTurmaNavigation").ToList();

                foreach(ObjetivoAluno _objetivo in _listaAlunosObjetivo)
                {
                    _objetivo.IdAlunoTurmaNavigation.ObjetivoAluno = null;
                }

                return _listaAlunosObjetivo;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public List<ObjetivoAluno> ProcurarObjetivosPorAluno(int _idAluno)
        {
            try
            {
                List<ObjetivoAluno> _listaObjetivosAluno = _contexto.ObjetivoAluno
                                            .Where(oba => oba.IdAlunoTurma == _idAluno)
                                            .Include("IdObjetivoNavigation").ToList();

                foreach(ObjetivoAluno _aluno in _listaObjetivosAluno)
                {
                    _aluno.IdObjetivoNavigation.ObjetivoAluno = null;
                }

                return _listaObjetivosAluno;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public ObjetivoAluno BuscarObjetivoDoAlunoPorId(int _idObjetivoAluno)
        {
            try
            {
                return _contexto.ObjetivoAluno.FirstOrDefault(oba => oba.Id == _idObjetivoAluno);
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public ObjetivoAluno CadastrarObjetivosDoAluno(ObjetivoAluno _objetivoAluno)
        {
            try
            {
                _objetivoAluno.DataAlcancado = DateTime.Now;

                _contexto.ObjetivoAluno.Add(_objetivoAluno);

                _contexto.SaveChanges();

                return _objetivoAluno;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public ObjetivoAluno AlterarObjetivosDoAluno(ObjetivoAluno _objetivoAluno)
        {
            try
            {
                ObjetivoAluno _objetivo = BuscarObjetivoDoAlunoPorId(_objetivoAluno.Id);

                _contexto.Entry(_objetivoAluno).State = EntityState.Modified;

                _contexto.SaveChanges();

                return _objetivoAluno;
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }

        public void ExcluirObjetivoDoAluno(int _idObjetivoAluno)
        {
            try
            {
                ObjetivoAluno _objetivoAlunoProcurada = BuscarObjetivoDoAlunoPorId(_idObjetivoAluno);

                _contexto.ObjetivoAluno.Remove(_objetivoAlunoProcurada);

                _contexto.SaveChanges();
            }
            catch (Exception _e)
            {

                throw new Exception(_e.Message);
            }
        }
    }
}
