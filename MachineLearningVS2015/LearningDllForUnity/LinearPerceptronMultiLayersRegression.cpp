#include <random>

#include "LinearPerceptronMultiLayersRegression.h"
#include "Model.h"

int* LinearPerceptronMultiLayersRegression_Creation(int inputSize, int* layersSize, int size)
{
	ModelMultiLayers* modelMultiLayers = new ModelMultiLayers();
	modelMultiLayers->numberOfInternLayers = size;
	modelMultiLayers->layers = new Layer*[modelMultiLayers->numberOfInternLayers];

	for(int i = 0; i < modelMultiLayers->numberOfInternLayers; ++i)
	{
		Layer* tempLayer = new Layer();
		tempLayer->layerNumber = i;
		tempLayer->numberOfModels = layersSize[i];
		tempLayer->models = new Model*[tempLayer->numberOfModels];

		for(int j = 0; j < tempLayer->numberOfModels; ++j)
		{
			Model* m = new Model();
			m->modelNumber = j;
			if(i == 0)
				m->numberOfParameters = inputSize;
			else
				m->numberOfParameters = modelMultiLayers->layers[i - 1]->numberOfModels;
			m->numberOfParameters++; // On ajoute le biais
			m->data = new double[m->numberOfParameters];

			for(int k = 0; k < m->numberOfParameters; ++k)
				m->data[k] = (double) ((double) rand() / (RAND_MAX) +1) / 2;
			tempLayer->models[j] = m;
		}

		modelMultiLayers->layers[i] = tempLayer;
	}

	return (int*) modelMultiLayers;
}

void LinearPerceptronMultiLayersRegression_Training(int* index, int size, int inputSize, double* inputInput, double* inputResult)
{
	ModelMultiLayers* m = (ModelMultiLayers*) index;
}

double LinearPerceptronMultiLayersRegression_Predict(int* index, int layerInd, int modelInd, double* input, int inputSize, int inputInd)
{
	ModelMultiLayers* m = (ModelMultiLayers*) index;

	return 0;
}

void LinearPerceptronMultiLayersRegression_Deletion(int* index)
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
