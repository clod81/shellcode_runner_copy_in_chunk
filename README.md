# C# loader that copies a chunk at the time of the shellcode in memory, rather that all at once

Uses p/invoke to copy an encoded shellcode in memory, 100 bytes (chunks) at the time, rather than all at once

Yes the code is shit, but meh so what - not like I have the whole day to write good pocs

Tested with Meterpreter staged rev HTTPS payload (`encode_shellcode.cs` is the code I used to encode the raw one)

![Windowz](https://github.com/clod81/shellcode_runner_copy_in_chunk/blob/main/1.png?raw=true "Windowz")

![Meterpreter](https://github.com/clod81/shellcode_runner_copy_in_chunk/blob/main/2.png?raw=true "Meterpreter")
