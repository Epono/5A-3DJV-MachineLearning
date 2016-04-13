#include <random>

#include "LinearPerceptronMultiLayersClassification.h"
#include "ModelMultiLayers.h"

int* LinearPerceptronMultiLayersClassification_Creation(int inputSize)
{
	ModelMultiLayers* m = new ModelMultiLayers();
	m->data = new double[inputSize + 1];

	m->previousLayers = (ModelMultiLayers**) malloc(sizeof(ModelMultiLayers*) * inputSize + 1);
	for(int i = 0; i < inputSize + 1; ++i)
	{
		m->previousLayers[i] = new ModelMultiLayers();
		m->previousLayers[i]->data = new double[inputSize + 2];
	}

	// On initialise les w en random
	for(int i = 0; i < inputSize + 1; ++i)
	{
		m->data[i] = (double) ((double) rand() / (RAND_MAX) +1) / 2;
	}
	return (int*) m;
}

void LinearPerceptronMultiLayersClassification_Training(int* index, int iterationsCount, int size, int inputSize, double* inputInput, double* inputResult)
{
	// On récupère le modèle
	Model* m = (Model*) index;

	double pas = 0.1;

	// Pour un certain nombre d'itérations
	for(int i = 0; i < iterationsCount; ++i)
	{
		int dataToTest = (rand() % size);
		double *dataTableToTest = new double[inputSize];

		// On remplit
		for(int j = 0; j < inputSize; ++j)
		{
			dataTableToTest[j] = inputInput[(dataToTest*inputSize) + j];
		}

		if(LinearPerceptronMultiLayersClassification_Predict(index, inputSize, dataTableToTest) != inputResult[dataToTest])
		{
			m->data[0] += pas * inputResult[dataToTest];
			for(int j = 0; j < inputSize; ++j)
			{
				m->data[j + 1] += pas * inputResult[dataToTest] * dataTableToTest[j];
			}
		}
	}
}


double LinearPerceptronMultiLayersClassification_Predict(int* index, int inputSize, double* input)
{
	Model* m = (Model*) index;

	double* data = m->data;
	double val = data[0];
	for(int i = 0; i < inputSize; ++i)
	{
		val += data[i + 1] * input[i];
	}
	return val;
}

// classify sigm -1 1
// result sans sigm

void LinearPerceptronMultiLayersClassification_Deletion(int* index)
{
	Model* m = (Model*) index;
	delete m->data;
	delete m;
}

// PLA 63 classification
// Rosenblatt classif
// Regression avec la matrice chiante
// alpha à 0.1

// Regression avec 3 points, ca doit donner un plan
// Regression avec 23 points, ca doit donner un plan qui essaye de passer au milieu