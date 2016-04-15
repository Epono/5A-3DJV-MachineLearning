#include <random>

#include "LinearPerceptronMultiLayersClassification.h"
#include "Model.h"

int* LinearPerceptronMultiLayersClassification_Creation(int inputSize, int* layersSize, int size)
{
	ModelMultiLayers* modelMultiLayers = new ModelMultiLayers();
	modelMultiLayers->numberOfLayers = size;
	modelMultiLayers->layers = new Layer*[modelMultiLayers->numberOfLayers];

	std::random_device rd;
	std::default_random_engine re;
	std::uniform_real_distribution<> dis(-1, 1);
	for(int i = 0; i < modelMultiLayers->numberOfLayers; ++i)
	{
		Layer* tempLayer = new Layer();
		tempLayer->layerNumber = i;
		tempLayer->numberOfModels = layersSize[i];
		tempLayer->models = new Model*[tempLayer->numberOfModels];

		for(int j = 0; j < tempLayer->numberOfModels; ++j)
		{
			Model* m = new Model();
			m->modelNumber = j;
			if (i == 0)
				m->numberOfParameters = inputSize;
			else
				m->numberOfParameters = modelMultiLayers->layers[i - 1]->numberOfModels;
			m->numberOfParameters++; // On ajoute le biais
			m->data = new double[m->numberOfParameters];

			for(int k = 0; k < m->numberOfParameters; ++k)
				m->data[k] = dis(re);
			tempLayer->models[j] = m;
		}

		modelMultiLayers->layers[i] = tempLayer;
	}

	return (int*) modelMultiLayers;
}

void LinearPerceptronMultiLayersClassification_Training(int* index, int iterationsCount, int size, int inputSize, double* inputInput, double* inputResult)
{
	// On récupère le modèle
	ModelMultiLayers* m = (ModelMultiLayers*) index;

	double pas = 0.1;
	std::random_device rd;
	std::default_random_engine re;
	std::uniform_int_distribution<> dis(0, size - 1);

	// Pour un certain nombre d'itérations
	for(int i = 0; i < iterationsCount; ++i)
	{
		int dataToTest = dis(re);
		double *dataTableToTest = new double[inputSize];
		// On remplit
		for(int j = 0; j < inputSize; ++j)
			dataTableToTest[j] = inputInput[(dataToTest*inputSize) + j];
		
		// Pour tous les neurones de la derniere couche on calcule le delta
		for (int j = 0; j < m->layers[m->numberOfLayers-1]->numberOfModels; ++j)
		{
			m->layers[m->numberOfLayers-1]->models[j]->x = LinearPerceptronMultiLayersClassification_Predict((int*)m, m->numberOfLayers-1, j, dataTableToTest, inputSize, 0);
			m->layers[m->numberOfLayers-1]->models[j]->delta = (1 - m->layers[m->numberOfLayers - 1]->models[j]->x * m->layers[m->numberOfLayers - 1]->models[j]->x) * (m->layers[m->numberOfLayers-1]->models[j]->x - inputResult[dataToTest]);
		}
		// De l'avant derniere jusque la premiere couche
		for (int j = m->numberOfLayers - 2; j >= 0; --j)
		{
			// On itere sur tous les neurones de la couche
			for (int k = 0; k < m->layers[j]->numberOfModels; ++k)
			{
				double sum(0.0);
				for (int l = 0; l < m->layers[j + 1]->numberOfModels; ++l)
					sum += m->layers[j + 1]->models[l]->data[k + 1] * m->layers[j + 1]->models[l]->delta;
				m->layers[j]->models[k]->delta = (1 - m->layers[j]->models[k]->x*m->layers[j]->models[k]->x) * sum;
			}
		}
		// On met a jour les poids
		for (int j = 0; j < m->numberOfLayers; ++j)
			for (int k = 0; k < m->layers[j]->numberOfModels; ++k)
				for (int l = 0; l < m->layers[j]->models[k]->numberOfParameters; ++l)
				{
					if (j == 0)
					{
						if(l == 0)
							m->layers[j]->models[k]->data[l] -= pas * m->layers[j]->models[k]->delta;
						else
							m->layers[j]->models[k]->data[l] -= pas * dataTableToTest[l-1] * m->layers[j]->models[k]->delta;
					}
					else
						m->layers[j]->models[k]->data[l] -= pas * m->layers[j-1]->models[k]->x * m->layers[j]->models[k]->delta;
				}
	}
}

double LinearPerceptronMultiLayersClassification_Predict(int* index, int layerInd, int modelInd, double* input, int inputSize, int inputInd)
{
	ModelMultiLayers* m = (ModelMultiLayers*) index;

	m->layers[layerInd]->models[modelInd]->x = m->layers[layerInd]->models[modelInd]->data[0];
	if (layerInd == 0)
	{
		for (int i = 0; i < inputSize; ++i)
			m->layers[layerInd]->models[modelInd]->x += m->layers[layerInd]->models[modelInd]->data[i + 1] * input[inputInd + i];
	}
	else
	{
		for (int i = 0; i < m->layers[layerInd - 1]->numberOfModels; ++i)
			m->layers[layerInd]->models[modelInd]->x += m->layers[layerInd]->models[modelInd]->data[i + 1] *
				LinearPerceptronMultiLayersClassification_Predict(index, layerInd - 1, i, input, inputSize, inputInd);
	}
	return tanh(m->layers[layerInd]->models[modelInd]->x); // Tanh de la somme des entrées pondérées
}

void LinearPerceptronMultiLayersClassification_Deletion(int* index)
{
	ModelMultiLayers* modelMultiLayers = (ModelMultiLayers*) index;

	std::random_device rd;
	std::default_random_engine re;
	std::uniform_real_distribution<> dis(-1, 1);
	for(int i = 0; i < modelMultiLayers->numberOfLayers; ++i)
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
