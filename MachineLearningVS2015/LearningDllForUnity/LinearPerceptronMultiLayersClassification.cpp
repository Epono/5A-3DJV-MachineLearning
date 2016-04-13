#include <random>

#include "LinearPerceptronMultiLayersClassification.h"
#include "Model.h"

int* LinearPerceptronMultiLayersClassification_Creation(int inputSize, int* layersSize, int size)
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
			if (i == 0)
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

double CalculEffectiveOutput(ModelMultiLayers* model, int layerInd, int modelInd)
{
	double result(0.0);
	if (layerInd == 0)
	{

	}
	else
	{

	}
	return tanh(result); // Tanh de la somme des entrées pondérées
}

void LinearPerceptronMultiLayersClassification_Training(int* index, int iterationsCount, int size, int inputSize, double* inputInput, double* inputResult)
{
	// On récupère le modèle
	ModelMultiLayers* m = (ModelMultiLayers*) index;

	double pas = 0.1;

	// Pour un certain nombre d'itérations
	for(int i = 0; i < iterationsCount; ++i)
	{
		int dataToTest = (rand() % size);
		double *dataTableToTest = new double[inputSize];
		// On remplit
		for(int j = 0; j < inputSize; ++j)
			dataTableToTest[j] = inputInput[(dataToTest*inputSize) + j];
		
		// Pour tous les neurones de la derniere couche on calcule le delta
		for (int j = 0; j < m->layers[m->numberOfInternLayers]->numberOfModels; ++j)
		{
			double xjl = CalculEffectiveOutput(m, m->numberOfInternLayers, j);
			m->layers[m->numberOfInternLayers]->models[j]->delta = (1 - xjl * xjl) * (xjl - inputResult[dataToTest]);
		}
		// De l'avant derniere jusque la premiere couche
		for (int j = m->numberOfInternLayers - 1; j >= 0; --j)
		{
			// On itere sur tous les neurones de la couche
			for (int k = 0; k < m->layers[j]->numberOfModels; ++k)
			{
				double sum(0.0);
				for (int l = 0; l < m->layers[j + 1]->numberOfModels; ++l)
					sum += m->layers[j + 1]->models[l]->data[k + 1] * m->layers[j + 1]->models[l]->delta;
				double xilm1 = CalculEffectiveOutput(m, j, k);
				m->layers[j]->models[k]->delta = (1 - xilm1*xilm1) * sum;
			}
		}
		// On met a jour les poids
		for (int j = 0; j < m->numberOfInternLayers; ++j)
			for (int k = 0; k < m->layers[j]->numberOfModels; ++k)
				for (int l = 0; l < m->layers[j]->models[k]->numberOfParameters; ++l)
					m->layers[j]->models[k]->data[l] -= pas * CalculEffectiveOutput(m, j, k) * m->layers[j]->models[k]->delta;
	}
}

double LinearPerceptronMultiLayersClassification_Predict(int* index, int inputSize, double* input)
{
	ModelMultiLayers* m = (ModelMultiLayers*) index;

	double* data = m->data;
	double val = data[0];
	for(int i = 0; i < inputSize; ++i)
	{
		val += data[i + 1] * input[i];
	}
	return val;
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
