using System.Globalization;
using System.Threading;
using System.Windows.Input;
using CalculationCore;
using ManagedHelpers;
using NewtonIntegrator.Interfaces;

namespace NewtonIntegrator.Views
{
    public sealed class MainWindowViewModel : DocumentViewModel<MainWindowView>
    {
        public Core Core { get; set; }
        public ICommand Start { get; set; }

        public MainWindowViewModel()
        {
            var ci = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
            View = new MainWindowView();
            Core = new Core();
            Core.IterationStepComplited += IterationStepComplited;
            Core.IterationComplited += IterationComplited;
            Start = new MyCommand<object>(OnStartCommand);
            SetInititalValues();
        }

        private void IterationComplited(double l1, double l2, double mk3, double a)
        {
            Lambda1 = l1;
            Lambda2 = l2;
            Lambda = a;
            Muk3 = mk3;

            var mu_pg = Lambda1*Lambda2*(Muk3*(1 + A3) - Mu3 - G3*9.8/Nu3 - A3);
            M1 = MassGo/mu_pg;
            M2 = Lambda1*M1;
            M3 = Lambda2*M2;
        }

        private void IterationStepComplited(double newValue)
        {
            Delta = newValue;
        }

        private void OnStartCommand(object obj)
        {
            Core.SetValues();
            Core.AutoIterate();
        }

        private void SetInititalValues()
        {
            MassGo = 3.0;
            Horb = 250;
            Jud1 = 3297.5;
            Jud2 = 3498;
            Jud3 = 3295.6;
            Nu1 = 0.75;
            Nu2 = 1.0;
            Nu3 = 1.2;
            Velocity = 9589.0;
            Mu1 = 0.047;
            Mu2 = 0.043;
            Mu3 = 0.037;
            G1 = 0.0012;
            G2 = 0.0015;
            G3 = 0.0018;
            A1 = 0.052;
            A2 = 0.046;
            A3 = 0.042;
            Lambda2 = Lambda1 = Lambda = Muk3 = 0.5;
            Epsilon = 1e-8;
        }

        public override string Title
        {
            get { return "Newton integrator"; }
        }

        #region MassGo

        private double massGo;

        public double MassGo
        {
            get { return massGo; }
            set
            {
                if (!Equals(value, massGo))
                {
                    massGo = value;
                    Core.ValueVector.Mgo = value;
                    OnPropertyChanged("MassGo");
                }
            }
        }

        #endregion

        #region Horb

        private double horb;

        public double Horb
        {
            get { return horb; }
            set
            {
                if (!Equals(value, horb))
                {
                    horb = value;
                    Core.ValueVector.Horb = value;
                    OnPropertyChanged("Horb");
                }
            }
        }

        #endregion

        #region Jud1

        private double jud1;

        public double Jud1
        {
            get { return jud1; }
            set
            {
                if (!Equals(value, jud1))
                {
                    jud1 = value;
                    Core.ValueVector.J1 = value;
                    OnPropertyChanged("Jud1");
                }
            }
        }

        #endregion

        #region Jud2

        private double jud2;

        public double Jud2
        {
            get { return jud2; }
            set
            {
                if (!Equals(value, jud2))
                {
                    jud2 = value;
                    Core.ValueVector.J2 = value;
                    OnPropertyChanged("Jud2");
                }
            }
        }

        #endregion

        #region Jud3

        private double jud3;

        public double Jud3
        {
            get { return jud3; }
            set
            {
                if (!Equals(value, jud3))
                {
                    jud3 = value;
                    Core.ValueVector.J3 = value;
                    OnPropertyChanged("Jud3");
                }
            }
        }

        #endregion

        #region Nu1

        private double nu1;

        public double Nu1
        {
            get { return nu1; }
            set
            {
                if (!Equals(value, nu1))
                {
                    nu1 = value;
                    Core.ValueVector.Nu1 = value;
                    OnPropertyChanged("Nu1");
                }
            }
        }

        #endregion

        #region Nu2

        private double nu2;

        public double Nu2
        {
            get { return nu2; }
            set
            {
                if (!Equals(value, nu2))
                {
                    nu2 = value;
                    Core.ValueVector.Nu2 = value;
                    OnPropertyChanged("Nu2");
                }
            }
        }

        #endregion

        #region Nu3

        private double nu3;

        public double Nu3
        {
            get { return nu3; }
            set
            {
                if (!Equals(value, nu3))
                {
                    nu3 = value;
                    Core.ValueVector.Nu3 = value;
                    OnPropertyChanged("Nu3");
                }
            }
        }

        #endregion  

        #region Velocity

        private double velocity;

        public double Velocity
        {
            get { return velocity; }
            set
            {
                if (!Equals(value, velocity))
                {
                    velocity = value;
                    Core.ValueVector.Vk = value;
                    OnPropertyChanged("Velocity");
                }
            }
        }

        #endregion

        #region Mu1

        private double mu1;

        public double Mu1
        {
            get { return mu1; }
            set
            {
                if (!Equals(value, mu1))
                {
                    mu1 = value;
                    Core.ValueVector.Mu1 = value;
                    OnPropertyChanged("Mu1");
                }
            }
        }

        #endregion

        #region Mu2

        private double mu2;

        public double Mu2
        {
            get { return mu2; }
            set
            {
                if (!Equals(value, mu2))
                {
                    mu2 = value;
                    Core.ValueVector.Mu2 = value;
                    OnPropertyChanged("Mu2");
                }
            }
        }

        #endregion

        #region Mu3

        private double mu3;

        public double Mu3
        {
            get { return mu3; }
            set
            {
                if (!Equals(value, mu3))
                {
                    mu3 = value;
                    Core.ValueVector.Mu3 = value;
                    OnPropertyChanged("Mu3");
                }
            }
        }

        #endregion

        #region G1

        private double g1;

        public double G1
        {
            get { return g1; }
            set
            {
                if (!Equals(value, g1))
                {
                    g1 = value;
                    Core.ValueVector.G1 = value;
                    OnPropertyChanged("G1");
                }
            }
        }

        #endregion

        #region G2

        private double g2;

        public double G2
        {
            get { return g2; }
            set
            {
                if (!Equals(value, g2))
                {
                    g2 = value;
                    Core.ValueVector.G2 = value;
                    OnPropertyChanged("G2");
                }
            }
        }

        #endregion

        #region G3

        private double g3;

        public double G3
        {
            get { return g3; }
            set
            {
                if (!Equals(value, g3))
                {
                    g3 = value;
                    Core.ValueVector.G3 = value;
                    OnPropertyChanged("G3");
                }
            }
        }

        #endregion

        #region A1

        private double a1;

        public double A1
        {
            get { return a1; }
            set
            {
                if (!Equals(value, a1))
                {
                    a1 = value;
                    Core.ValueVector.As1 = value;
                    OnPropertyChanged("A1");
                }
            }
        }

        #endregion

        #region A2

        private double a2;

        public double A2
        {
            get { return a2; }
            set
            {
                if (!Equals(value, a2))
                {
                    a2 = value;
                    Core.ValueVector.As2 = value;
                    OnPropertyChanged("A2");
                }
            }
        }

        #endregion

        #region A3

        private double a3;

        public double A3
        {
            get { return a3; }
            set
            {
                if (!Equals(value, a3))
                {
                    a3 = value;
                    Core.ValueVector.As3 = value;
                    OnPropertyChanged("A3");
                }
            }
        }

        #endregion

        #region Lambda1

        private double lambda1;

        public double Lambda1
        {
            get { return lambda1; }
            set
            {
                if (!Equals(value, lambda1))
                {
                    lambda1 = value;
                    Core.ValueVector.Lambda1 = value;
                    OnPropertyChanged("Lambda1");
                }
            }
        }

        #endregion

        #region Lambda2

        private double lambda2;

        public double Lambda2
        {
            get { return lambda2; }
            set
            {
                if (!Equals(value, lambda2))
                {
                    lambda2 = value;
                    Core.ValueVector.Lambda2 = value;
                    OnPropertyChanged("Lambda2");
                }
            }
        }

        #endregion

        #region Muk3

        private double muk3;

        public double Muk3
        {
            get { return muk3; }
            set
            {
                if (!Equals(value, muk3))
                {
                    muk3 = value;
                    Core.ValueVector.Muk3 = value;
                    OnPropertyChanged("Muk3");
                }
            }
        }

        #endregion

        #region Lambda

        private double lambda;

        public double Lambda
        {
            get { return lambda; }
            set
            {
                if (!Equals(value, lambda))
                {
                    lambda = value;
                    Core.ValueVector.Lambda = value;
                    OnPropertyChanged("Lambda");
                }
            }
        }

        #endregion

        #region Epsilon

        private double epsilon;

        public double Epsilon
        {
            get { return epsilon; }
            set
            {
                if (!Equals(value, epsilon))
                {
                    epsilon = value;
                    Core.Epsilon = value;
                    OnPropertyChanged("Epsilon");
                }
            }
        }

        #endregion

        #region Delta

        private double delta;

        public double Delta
        {
            get { return delta; }
            set
            {
                if (!Equals(value, delta))
                {
                    delta = value;
                    OnPropertyChanged("Delta");
                }
            }
        }

        #endregion

        #region M1

        private double m1;

        public double M1
        {
            get { return m1; }
            set
            {
                if (!Equals(value, m1))
                {
                    m1 = value;
                    OnPropertyChanged("M1");
                }
            }
        }

        #endregion        

        #region M2

        private double m2;

        public double M2
        {
            get { return m2; }
            set
            {
                if (!Equals(value, m2))
                {
                    m2 = value;
                    OnPropertyChanged("M2");
                }
            }
        }

        #endregion 
   
        #region M3

        private double m3;

        public double M3
        {
            get { return m3; }
            set
            {
                if (!Equals(value, m3))
                {
                    m3 = value;
                    OnPropertyChanged("M3");
                }
            }
        }

        #endregion    
    }
}
