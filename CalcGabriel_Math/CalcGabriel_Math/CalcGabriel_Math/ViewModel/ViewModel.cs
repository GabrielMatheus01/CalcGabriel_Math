using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CalcGabriel_Math.ModelView
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int? _resultado;

        public int? Resultado1
        {
            get { return _resultado; }
            set
            {
                _resultado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Resultado1)));

            }
        }
        public int? Resultado2
        {
            get { return _resultado; }
            set
            {
                _resultado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Resultado2)));


            }
        }
        public int? Resultado
        {
            get { return _resultado; }
            set
            {
                _resultado = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Resultado)));


            }


        }

        private Operacao? _operacao;
        private int _numero1;
        private int _numero2;

        public ICommand Limpar { get; }
        private void LimpaTudo()
        {
            _numero1 = 0;
            _numero2 = 0;
            _operacao = null;
            Resultado = null;
            Resultado1 = null;
            Resultado2 = null;
        }
        public ViewModel()
        {
            _numero1 = 0;
            _numero2 = 0;

            InsereNumeroCommand = new Command<string>(InsereNumero);
            Limpar = new Command(LimpaTudo);
            InsereOperacaoCommand = new Command<string>(InsereOperacao);
            RealizaOperacaoCommand = new Command(RealizaOperacao);


        }
        public ICommand InsereNumeroCommand { get; }
        private void InsereNumero(string numeroInserido)
        {
            if (_operacao == null)
            {
                _numero1 = _numero1 * 10 + Convert.ToInt32(numeroInserido);
                Resultado1 = _numero1;
            }
            else
            {
                _numero2 = _numero2 * 10 + Convert.ToInt32(numeroInserido);
                Resultado2 = _numero2;
            }
        }
        public ICommand InsereOperacaoCommand { get; }
        private void InsereOperacao(string operacao)
        {
            if (operacao == "+")
                _operacao = Operacao.Soma;
            if (operacao == "-")
                _operacao = Operacao.Subtracao;
            if (operacao == "*")
                _operacao = Operacao.Multiplicacao;
            if (operacao == "/")
                _operacao = Operacao.Divisao;
        }
        public ICommand RealizaOperacaoCommand { get; }
        private void RealizaOperacao()
        {
            switch (_operacao)
            {
                case Operacao.Soma:
                    _numero1 = _numero1 + _numero2;
                    break;
                case Operacao.Subtracao:
                    _numero1 = _numero1 - _numero2;
                    break;
                case Operacao.Multiplicacao:
                    _numero1 = _numero1 * _numero2;
                    break;
                case Operacao.Divisao:
                    try
                    {
                        _numero1 = _numero1 / _numero2;
                    }
                    catch
                    {
                        _numero1 = 0;

                    }

                    break;
                case null:
                    return;



            }


            Resultado = _numero1;
            _numero2 = 0;
            _operacao = null;


        }

    }

    public enum Operacao
    {
        Soma,
        Subtracao,
        Multiplicacao,
        Divisao
    }

}
