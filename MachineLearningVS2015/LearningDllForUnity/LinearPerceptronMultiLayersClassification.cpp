#include <random>

#include "LinearPerceptronMultiLayersClassification.h"
#include "Model.h"

int* LinearPerceptronMultiLayersClassification_Creation(int inputSize)
{
	ModelMultiLayers* modelMultiLayers = new ModelMultiLayers();
	modelMultiLayers->numberOfInternLayers = 1;
	modelMultiLayers->layers = (Layer**) malloc(sizeof(Layer*) * modelMultiLayers->numberOfInternLayers);

	for(int i = 0; i < modelMultiLayers->numberOfInternLayers; ++i)
	{
		Layer* tempLayer = new Layer();
		tempLayer->layerNumber = i;
		tempLayer->numberOfModels = inputSize + tempLayer->layerNumber + 1;
		tempLayer->models = (Model**) malloc(sizeof(Model*) * tempLayer->numberOfModels);

		for(int j = 0; j < tempLayer->numberOfModels; ++j)
		{
			Model* m = new Model();
			m->modelNumber = j;
			m->numberOfParameters = tempLayer->numberOfModels;
			m->data = new double[m->numberOfParameters];

			for(int k = 0; k < m->numberOfParameters; ++k)
			{
				m->data[k] = (double) ((double) rand() / (RAND_MAX) +1) / 2;
			}

			tempLayer->models[j] = m;
		}

		modelMultiLayers->layers[i] = tempLayer;
	}

	return (int*) modelMultiLayers;
}

void LinearPerceptronMultiLayersClassification_Training(int* index, int iterationsCount, int size, int inputSize, double* inputInput, double* inputResult)
{
	//// On récupère le modèle
	//Model* m = (Model*) index;

	//double pas = 0.1;

	//// Pour un certain nombre d'itérations
	//for(int i = 0; i < iterationsCount; ++i)
	//{
	//	int dataToTest = (rand() % size);
	//	double *dataTableToTest = new double[inputSize];

	//	// On remplit
	//	for(int j = 0; j < inputSize; ++j)
	//	{
	//		dataTableToTest[j] = inputInput[(dataToTest*inputSize) + j];
	//	}

	//	if(LinearPerceptronMultiLayersClassification_Predict(index, inputSize, dataTableToTest) != inputResult[dataToTest])
	//	{
	//		m->data[0] += pas * inputResult[dataToTest];
	//		for(int j = 0; j < inputSize; ++j)
	//		{
	//			m->data[j + 1] += pas * inputResult[dataToTest] * dataTableToTest[j];
	//		}
	//	}
	//}
}

double LinearPerceptronMultiLayersClassification_Predict(int* index, int inputSize, double* input)
{
	//Model* m = (Model*) index;

	//double* data = m->data;
	//double val = data[0];
	//for(int i = 0; i < inputSize; ++i)
	//{
	//	val += data[i + 1] * input[i];
	//}
	//return val;
	return 0;
}

void LinearPerceptronMultiLayersClassification_Deletion(int* index)
{
	ModelMultiLayers* modelMultiLayers = (ModelMultiLayers*) index;

	for(int i = 0; i < modelMultiLayers->numberOfInternLayers; ++i)
	{
		Layer* tempLayer = modelMultiLayers->layers[i];

		for(int j = 0; j < tempLayer->numberOfModels; ++j)
		{
			Model* m = tempLayer->models[j];
			delete[] m->data;
		}
		delete[] tempLayer->models;
	}
	delete[] modelMultiLayers->layers;
}
