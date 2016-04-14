#pragma once

extern "C" {
	__declspec(dllexport) int* LloydsRBF_Creation(int inputSize);
	__declspec(dllexport) void LloydsRBF_Classification_Training(int* index, int iterationsCount, int size, int inputSize, double* inputInput, double* inputResult);
	__declspec(dllexport) void LloydsRBF_Regression_Training(int* index, int size, int inputSize, double* inputInput, double* inputResult);
	__declspec(dllexport) double LloydsRBF_Classification_Predict(int* index, int inputSize, double* input);
	__declspec(dllexport) double LloydsRBF_Regression_Predict(int* index, int inputSize, double* input);
	__declspec(dllexport) void LloydsRBF_Deletion(int* index);
}