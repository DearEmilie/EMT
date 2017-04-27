using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using EMT.Annotations;

namespace EMT
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private int _firstTerm = 12;
        private int _secondTerm = 12;
        private int _answer = 144;

        private Random _random = new Random();
        private int _firstTermMinimum = 0;
        private int _firstTermMaximum = 2;

        public MainWindow()
        {
            InitializeComponent();
        }

        public int FirstTerm
        {
            get { return _firstTerm; }
            set
            {
                if (value == _firstTerm) return;
                _firstTerm = value;
                OnPropertyChanged();
            }
        }

        public int FirstTermMinimum
        {
            get { return _firstTermMinimum; }
            set
            {
                if (value == _firstTermMinimum) return;
                _firstTermMinimum = value;
                OnPropertyChanged();
            }
        }

        public int FirstTermMaximum
        {
            get { return _firstTermMaximum; }
            set
            {
                if (value == _firstTermMaximum) return;
                _firstTermMaximum = value;
                OnPropertyChanged();
            }
        }

        public int SecondTerm
        {
            get { return _secondTerm; }
            set
            {
                if (value == _secondTerm) return;
                _secondTerm = value;
                OnPropertyChanged();
            }
        }

        public int Answer
        {
            get { return _answer; }
            set
            {
                if (value == _answer) return;
                _answer = value;
                OnPropertyChanged();
            }
        }


        public void CheckAnswer()
        {
            var expectedAnswer = FirstTerm*SecondTerm;

            if (expectedAnswer != Answer)
                TextBoxAnswer.Background = Brushes.Salmon;
            else
            {
                TextBoxAnswer.Background = Brushes.MediumAquamarine;
                FirstTerm = _random.Next(FirstTermMinimum, FirstTermMaximum + 1);
                SecondTerm = _random.Next(0, 13);
                
                TextBoxAnswer.SelectAll();
            }
        }

        private void TextBoxAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                CheckAnswer();

            else
                TextBoxAnswer.Background = Brushes.White;
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}