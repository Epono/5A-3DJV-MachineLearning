#pragma once

extern "C" {
	__declspec(dllexport) double* LinearPerceptronRegression_Creation(int input);
	__declspec(dllexport) double LinearPerceptronRegression_Training(int input);
	__declspec(dllexport) double LinearPerceptronRegression_Result(int input);
	__declspec(dllexport) double LinearPerceptronRegression_Deletion(int input);
}
