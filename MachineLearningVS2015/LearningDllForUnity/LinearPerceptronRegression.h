#pragma once

extern "C" {
	__declspec(dllexport) int* LinearPerceptronRegression_Creation(int inputSize);
	__declspec(dllexport) void LinearPerceptronRegression_Training(int* index, int size, int inputSize, double* inputInput, double* inputResult);
	__declspec(dllexport) double LinearPerceptronRegression_Predict(int* index, int inputSize, double* input);
	__declspec(dllexport) void LinearPerceptronRegression_Deletion(int* index);
}