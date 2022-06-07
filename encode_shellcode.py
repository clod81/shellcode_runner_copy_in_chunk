#!/usr/bin/python3

import sys

if len(sys.argv) != 3:
	print("Usage: %s <shellcode.bin> <key>\n" % (sys.argv[0]))
	sys.exit(1)

output = ''
file = open(sys.argv[1], 'rb')
key = int(sys.argv[2])

contents = file.read()
file.close()

encoded = []
for b in range(len(contents)):
	test = contents[b]
	test = (test + key) & 0xFF
	encoded.append("{:02x}".format(test))

count = 0
for x in encoded:
	if count < len(encoded)-1:
		output += "0x{}, ".format(x)
		count += 1
	else:
		output += "0x{}".format(x)
		count += 1
	if count % 20 == 0:
		output += "\n"

print(output)
