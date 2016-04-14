#pragma once

extern "C" {
	__declspec(dllexport) int* LinearPerceptronMultiLayersRegression_Creation(int inputSize, int* layersSize, int size);
	__declspec(dllexport) void LinearPerceptronMultiLayersRegression_Training(int* index, int size, int inputSize, double* inputInput, double* inputResult);
	__declspec(dllexport) double LinearPerceptronMultiLayersRegression_Predict(int* index, int layerInd, int modelInd, double* input, int inputSize, int inputInd);
	__declspec(dllexport) void LinearPerceptronMultiLayersRegression_Deletion(int* index);
}