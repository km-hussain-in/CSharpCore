using System;
using System.IO;
using System.IO.MemoryMappedFiles;

namespace FileIOTest
{
	class Support
	{
		public void Run(string[] args)
		{
			if(args.Length > 1 && args[0] == "-s")
				UseFileStream(args[1]);
			else if(args.Length > 1 && args[0] == "-m")
				UseMemoryMappedFile(args[1]);
			else
				Console.WriteLine("Invalid command!");
		}

		private static void UseFileStream(string fileToReverse)
		{
			using(var stream = new FileStream(fileToReverse, FileMode.Open, FileAccess.ReadWrite))
			{
				int sz = (int)stream.Length;
				byte[] buffer = new byte[sz];
				stream.Read(buffer, 0, sz);
				for(int i = 0, j = sz - 1; i < j; ++i, j--)
				{
					byte ib = buffer[i];
					byte jb = buffer[j];
					buffer[i] = jb;
					buffer[j] = ib;
				}
				stream.Position = 0;
				stream.Write(buffer, 0, sz);
			}
		}


		private static void UseMemoryMappedFile(string fileToReverse)
		{
			FileInfo info = new FileInfo(fileToReverse);
			using(var mapping = MemoryMappedFile.CreateFromFile(fileToReverse))
			{
				using(var view = mapping.CreateViewAccessor(0, info.Length))
				{
					for(long i = 0, j = info.Length - 1; i < j; ++i, j--)
					{
						byte ib = view.ReadByte(i);
						byte jb = view.ReadByte(j);
						view.Write(i, jb);
						view.Write(j, ib);
					}
				}
			}
		}
	}
}
