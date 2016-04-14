#pragma once

extern "C" {
	__declspec(dllexport) int* LinearPerceptronMultiLayersClassification_Creation(int inputSize, int* layersSize, int size);
	__declspec(dllexport) void LinearPerceptronMultiLayersClassification_Training(int* index, int iterationsCount, int size, int inputSize, double* inputInput, double* inputResult);
	__declspec(dllexport) double LinearPerceptronMultiLayersClassification_Predict(int* index, int layerInd, int modelInd, double* input, int inputSize, int inputInd);
	__declspec(dllexport) void LinearPerceptronMultiLayersClassification_Deletion(int* index);
}