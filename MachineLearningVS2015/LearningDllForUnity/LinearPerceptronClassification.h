#pragma once

extern "C" {
	__declspec(dllexport) int* LinearPerceptronClassification_Creation(int dimension);
	__declspec(dllexport) void LinearPerceptronClassification_Training(int* index, int input);
	__declspec(dllexport) double LinearPerceptronClassification_Predict(int* index);
	__declspec(dllexport) void LinearPerceptronClassification_Deletion(int* index);
}