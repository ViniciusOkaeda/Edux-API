using EduxProject.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxProject.Interfaces
{
    interface IObjetivoAluno
    {
        List<ObjetivoAluno> ListarObjetivosDosAlunos();
        List<ObjetivoAluno> ProcurarAlunosPorObjetivo(int _idObjetivo);
        List<ObjetivoAluno> ProcurarObjetivosPorAluno(int _idAluno);
        ObjetivoAluno BuscarObjetivoDoAlunoPorId(int _idObjetivoAluno);
        ObjetivoAluno CadastrarObjetivosDoAluno(ObjetivoAluno _objetivoAluno);
        ObjetivoAluno AlterarObjetivosDoAluno(ObjetivoAluno _objetivoAluno);
        void ExcluirObjetivoDoAluno(int _idObjetivoAluno);
    }
}
