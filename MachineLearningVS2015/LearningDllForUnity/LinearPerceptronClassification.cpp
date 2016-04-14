#include <random>

#include "LinearPerceptronClassification.h"
#include "Model.h"

int* LinearPerceptronClassification_Creation(int inputSize)
{
	Model* m = new Model();
	m->data = new double[inputSize + 1];

	std::random_device rd;
	std::default_random_engine re;
	std::uniform_real_distribution<> dis(-1, 1);
	// On initialise les w en random entre -1 et 1
	for(int i = 0; i < inputSize + 1; ++i)
		m->data[i] = dis(re);
	return (int*) m;
}

void LinearPerceptronClassification_Training(int* index, int iterationsCount, int size, int inputSize, double* inputInput, double* inputResult)
{
	// On récupère le modèle
	Model* m = (Model*) index;

	double pas = 0.1;
	std::random_device rd;
	std::default_random_engine re;
	std::uniform_int_distribution<> dis(0, size-1);

	// Pour un certain nombre d'itérations
	for(int i = 0; i < iterationsCount; ++i)
	{
		int dataToTest = dis(re);
		double *dataTableToTest = new double[inputSize];

		// On remplit
		for(int j = 0; j < inputSize; ++j)
		{
			dataTableToTest[j] = inputInput[(dataToTest*inputSize) + j];
		}

		if(LinearPerceptronClassification_Predict(index, inputSize, dataTableToTest) != inputResult[dataToTest])
		{
			m->data[0] += pas * inputResult[dataToTest];
			for(int j = 0; j < inputSize; ++j)
			{
				m->data[j + 1] += pas * inputResult[dataToTest] * dataTableToTest[j];
			}
		}
	}
}

double LinearPerceptronClassification_Predict(int* index, int inputSize, double* input)
{
	Model* m = (Model*) index;

	double* data = m->data;
	double val = data[0];
	for(int i = 0; i < inputSize; ++i)
	{
		val += data[i + 1] * input[i];
	}
	return (val < 0 ? -1 : 1);
}

// classify sigm -1 1
// result sans sigm

void LinearPerceptronClassification_Deletion(int* index)
{
	Model* m = (Model*) index;
	delete[] m->data;
	delete m;
}

// PLA 63 classification
// Rosenblatt classif
// Regression avec la matrice chiante
// alpha à 0.1

// Regression avec 3 points, ca doit donner un plan
// Regression avec 23 points, ca doit donner un plan qui essaye de passer au milieu