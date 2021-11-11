using System;
using System.IO;

namespace ELFSharp.Utilities
{
    internal static class Extensions
    {
        public static byte[] ReadBytesOrThrow(this Stream stream, int count)
        {
            var result = new byte[count];
            while(count > 0)
            {
                var readThisTurn = stream.Read(result, result.Length - count, count);
                if (readThisTurn == 0)
                {
                    // Fast, crude fix for strange binary - need to analyse further.
                    Console.WriteLine($"End of stream reached while {count} bytes more expected.");
                    return result;

                }
                count -= readThisTurn;
            }
            return result;
        }
    }
}
