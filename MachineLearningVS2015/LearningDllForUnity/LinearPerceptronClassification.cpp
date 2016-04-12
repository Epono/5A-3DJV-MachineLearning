#include <random>

#include "LinearPerceptronClassification.h"
#include "Model.h"

int* LinearPerceptronClassification_Creation(int inputSize)
{
	Model* m = new Model();
	m->data = new double[inputSize + 1];

	// On initialise les w en random
	for(int i = 0; i < inputSize; ++i)
	{
		m->data[i] = (double) ((double) rand() / (RAND_MAX) +1) / 2;
	}
	return (int*) m;
}

void LinearPerceptronClassification_Training(int* index, int size, int inputSize, double* inputInput, double* inputResult)
{
	// On récupère le modèle
	Model* m = (Model*) index;

	// Pour chaque exemple (ex : aux coordonnées (2, 3), la boule est en -1)
	for(int i = 0; i < size; ++i)
	{
		// On regarde si on prédit bien
		if(LinearPerceptronClassification_Predict(index, inputSize, new double[] { inputInput[i], inputInput[i + 1] }) != inputResult[i])
		{
			//TODO Rosenblatt
		}
	}
	// X = tablea de tableau, entree de tous les exemples (points reperes) [[0.1, 0.2], [0.1, 0.2], [0.1, 0.2], [0.1, 0.2]]
	// => inputSize de 2
	// Y = tableau de résult [1, 1, -1, 1]
}

double LinearPerceptronClassification_Predict(int* index, int inputSize, double* input)
{
	Model* m = (Model*) index;
	return 1;
}

// classify sigm -1 1
// result sans sigm

void LinearPerceptronClassification_Deletion(int* index)
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