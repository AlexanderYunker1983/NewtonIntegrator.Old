using System;
using OpenTK;

namespace CalculationCore
{
    public class ValueVector
    {
        public double Mgo { get; set; }
        public double Horb { get; set; }
        public double J1 { get; set; }
        public double J2 { get; set; }
        public double J3 { get; set; }
        public double Nu1 { get; set; }
        public double Nu2 { get; set; }
        public double Nu3 { get; set; }
        public double Mu1 { get; set; }
        public double Mu2 { get; set; }
        public double Mu3 { get; set; }
        public double G1 { get; set; }
        public double G2 { get; set; }
        public double G3 { get; set; }
        public double Vk { get; set; }
        public double As1 { get; set; }
        public double As2 { get; set; }
        public double As3 { get; set; }
        public double Lambda1 { get; set; }
        public double Lambda2 { get; set; }
        public double Lambda { get; set; }
        public double Muk3 { get; set; }

        public const double G0 = 9.8;
        
        public double A1 
        {
            get { return Muk3*(1.0 + As1) - Mu3 - G3*G0/Nu3 - As3; }
        }

        public double B1
        {
            get { return Lambda1 + Mu1 + G1*G0/Nu1 + As1; }
        }

        public double B2
        {
            get { return Lambda2 + Mu2 + G2 * G0 / Nu2 + As2; }
        }

        public Vector4d GetFx0()
        {
            return new Vector4d(
                -Mgo / (Math.Pow(Lambda1, 2.0) * Lambda2 * A1) + Lambda * J1 / B1,
                -Mgo / (Lambda1 * Math.Pow(Lambda2, 2.0) * A1) + Lambda * J2 / B2,
                -Mgo * (1.0 + As3) / (Lambda1 * Lambda2 * Math.Pow(A1, 2.0)) + Lambda * J3 / Muk3,
                Vk + J1*Math.Log(B1/(1.0 + As1)) + J2*Math.Log(B2/(1 + As2)) + J3*Math.Log(Muk3)
                );
        }

        public Matrix4d GetJakobi()
        {
            return new Matrix4d
                {
                    Row0 = new Vector4d(
                        2.0 * Mgo / (Math.Pow(Lambda1, 3.0) * Lambda2 * A1) - Lambda * J1 / Math.Pow(B1, 2.0),
                        Mgo / (Math.Pow(Lambda1, 2.0) * Math.Pow(Lambda2, 2.0) * A1),
                        Mgo*(1.0 + As3) / (Math.Pow(Lambda1, 2.0) * Lambda2 * Math.Pow(A1, 2.0)),
                        J1/B1),
                    Row1 = new Vector4d(
                        Mgo / (Math.Pow(Lambda1, 2.0) * Math.Pow(Lambda2, 2.0) * A1),
                        2.0 * Mgo / (Lambda1 * Math.Pow(Lambda2, 3.0) * A1) - Lambda * J2 / (B2 * B2),
                        Mgo*(1.0 + As3) / (Lambda1 * Math.Pow(Lambda2, 2.0) * Math.Pow(A1, 2.0)),
                        J2/B2),
                    Row2 = new Vector4d(
                        Mgo*(1.0 + As3) / (Math.Pow(Lambda1, 2.0) * Lambda2 * Math.Pow(A1, 2.0)),
                        Mgo*(1.0 + As3) / (Lambda1 * Math.Pow(Lambda2, 2.0) * Math.Pow(A1, 2.0)),
                        2.0 * Mgo * (1.0 + As3) * (1.0 + As3) / (Lambda1 * Lambda2 * Math.Pow(A1, 3.0)) 
                            - Lambda * J3 / Math.Pow(Muk3, 2.0),
                        J3/Muk3),
                    Row3 = new Vector4d(
                        J1/B1,
                        J2/B2,
                        J3/Muk3,
                        0)
                };
        }
    }
}
