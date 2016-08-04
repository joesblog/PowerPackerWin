// PowerPacker32.cpp : Defines the exported functions for the DLL application.
//

#include "stdafx.h"
#include <stdio.h>
#include "PowerPacker.h"
#include <limits.h>
#include <string>
extern "C"
{
	_declspec(dllexport) void dumpToFile(const char* source, const char* destination)
	{
		CPowerPacker PP;
		PP.UnpackFile(source);
		PP.SaveToFile(destination);
		PP.~CPowerPacker();
	}


	_declspec(dllexport)  const char*  convert(const char* source)
	{

		CPowerPacker PP;
		PP.UnpackFile(source); // unpack the file
		unsigned char* dat = PP.GetUnpackedData(); //get the data
		char* res ;
		int arrSize = (int)PP.GetUnpackedSize(); // get the size of the data
		res = (char(*))malloc(arrSize + 1); // allocate some memory 

		strcpy(res, (char *)dat); //copy the returned data into memory
	 
		PP.~CPowerPacker(); //deconstruct
	
		return res;
	
	}


}
