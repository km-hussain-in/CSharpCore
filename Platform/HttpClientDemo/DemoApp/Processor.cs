using System;
using System.IO;

namespace DemoApp
{
    public class Processor
    {
        private ITransformer injected;

        public Processor(ITransformer transformer) => injected = transformer;

        public byte[] Process(Stream input, int size)
        {
            byte[] buffer = new byte[size];
            input.Read(buffer, 0, size);
            injected.Transform(buffer, size);
            return buffer;
        }
    }

    public class ProcessorFactory
    {
        public static readonly ProcessorFactory Provider = new ProcessorFactory();

        private ProcessorFactory() {}

        private ITransformer transformer;

        public void Attach<T>() where T : ITransformer, new()
        {
            transformer = new T();
        }

        public Processor CreateProcessor()
        {
            return new Processor(transformer);
        }
    }

} 

