# C# loader that copies a chunk at the time of the shellcode in memory, rather that all at once

Uses p/invoke to copy an encoded shellcode in memory, 100 bytes (chunks) at the time, rather than all at once

Yes the code is shit, but meh so what - not like I have the whole day to write good pocs

Tested with Meterpreter staged rev HTTPS payload

![Windowz](https://github.com/clod81/shellcode_runner_copy_in_chunk/raw/master/1.png "Windowz")

![Meterpreter](https://github.com/clod81/shellcode_runner_copy_in_chunk/raw/master/2.png "Meterpreter")
