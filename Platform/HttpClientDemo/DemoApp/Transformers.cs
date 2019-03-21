namespace DemoApp
{
    public interface ITransformer
    {
        void Transform(byte[] buffer, int count);
    }

    public class EncodingTransformer : ITransformer
    {
        public void Transform(byte[] buffer, int count)
        {
            for(int i = 0; i < count; ++i)
                buffer[i] = (byte)(buffer[i] ^ '#');
        }       
    } 

    public class ReversingTransformer : ITransformer
    {
        public void Transform(byte[] buffer, int count)
        {
            for(int i = 0, j = count - 1; i < j; ++i, j--)
            {
                byte ib = buffer[i];
                buffer[i] = buffer[j];
                buffer[j] = ib;
            }
        }       
    }

}
