using OpenTK;

namespace CalculationCore
{
    public static class ExtensionMethods
    {
        public static Vector4d Multiply(this Matrix4d matrix, Vector4d vector)
        {
            return new Vector4d(Vector4d.Dot(matrix.Row0, vector), Vector4d.Dot(matrix.Row1, vector),
                                Vector4d.Dot(matrix.Row2, vector), Vector4d.Dot(matrix.Row3, vector));
        }       
    }
}
