using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper{
	class Program{
		static void Main(string[] args) {
			if (args.Length == 0){
				Console.WriteLine("Usage: enc.exe key");
				return; 
			}
			int key = Int32.Parse(args[0]);
			// REPLACE buf WITH SHELLCODE
			byte[] buf = new byte[752] { 0xfc,0x48,0x83,0xe4,0xf0,...};
			byte[] encoded = new byte[buf.Length];
			for(int i = 0; i < buf.Length; i++){
				encoded[i] = (byte)(((uint)buf[i] + key) & 0xFF);
			}
			StringBuilder hex = new StringBuilder(encoded.Length * 2);
			foreach(byte b in encoded){
				hex.AppendFormat("0x{0:x2}, ", b);
			}
			Console.WriteLine(hex.ToString());
		}
	}
}
