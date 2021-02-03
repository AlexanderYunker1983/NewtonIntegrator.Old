using System;
using OpenTK;

namespace CalculationCore
{
    public class Core
    {
        public double Epsilon { get; set; }
        public double Delta { get; set; }
        public double IterationStep { get; private set; }
        private Vector4d CurrentValue { get; set; }
        public readonly ValueVector ValueVector = new ValueVector();

        public void SetValues()
        {
            CurrentValue = new Vector4d(ValueVector.Lambda1, ValueVector.Lambda2, ValueVector.Muk3, ValueVector.Lambda);
        }

        private void CheckValueVector()
        {
            ValueVector.Lambda1 = CurrentValue.X;
            ValueVector.Lambda2 = CurrentValue.Y;
            ValueVector.Muk3 = CurrentValue.Z;
            ValueVector.Lambda = CurrentValue.W;
        }

        public void Itarate()
        {
            IterationStep++;
            CheckValueVector();
            
            var coreVector = ValueVector.GetFx0();
            var matrix = ValueVector.GetJakobi();
            
            matrix.Invert();

            var multyplingResult = matrix.Multiply(-1.0 * coreVector);
            
            Delta = multyplingResult.Length;
            
            CurrentValue = CurrentValue + multyplingResult;
            
            CheckValueVector();
            OnIterationStepComplited(Delta);
        }

        public event Action<double> IterationStepComplited;
        private void OnIterationStepComplited(double newValue)
        {
            var handler = IterationStepComplited;
            if (handler != null) handler(newValue);
        }

        public event Action<double,double,double,double> IterationComplited;
        private void OnIterationComplited()
        {
            var handler = IterationComplited;
            if (handler != null) handler(ValueVector.Lambda1, ValueVector.Lambda2, ValueVector.Muk3, ValueVector.Lambda);
            OnIterationStepComplited(Delta);
        }

        public void AutoIterate()
        {
            do Itarate(); while (Delta > Epsilon);
            OnIterationComplited();
        }
    }
}
