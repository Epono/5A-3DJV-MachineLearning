#pragma once

extern "C" {
	__declspec(dllexport) int* BasicRBF_Creation(int inputSize);
	__declspec(dllexport) void BasicRBF_Classification_Training(int* index, int iterationsCount, int size, int inputSize, double* inputInput, double* inputResult);
	__declspec(dllexport) void BasicRBF_Regression_Training(int* index, int size, int inputSize, double* inputInput, double* inputResult);
	__declspec(dllexport) double BasicRBF_Classification_Predict(int* index, int inputSize, double* input);
	__declspec(dllexport) double BasicRBF_Regression_Predict(int* index, int inputSize, double* input);
	__declspec(dllexport) void BasicRBF_Deletion(int* index);
}