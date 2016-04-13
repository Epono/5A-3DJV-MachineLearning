#pragma once

extern "C" {
	__declspec(dllexport) int* LinearPerceptronClassification_Creation(int inputSize);
	__declspec(dllexport) void LinearPerceptronClassification_Training(int* index, int iterationsCount, int size, int inputSize, double* inputInput, double* inputResult);
	__declspec(dllexport) double LinearPerceptronClassification_Predict(int* index, int inputSize, double* input);
	__declspec(dllexport) void LinearPerceptronClassification_Deletion(int* index);
}