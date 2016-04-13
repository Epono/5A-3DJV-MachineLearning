#include <random>

#include "LinearPerceptronRegression.h"
#include "Model.h"

#include "Dense"

int* LinearPerceptronRegression_Creation(int inputSize)
{
	Model* m = new Model();
	m->data = new double[inputSize + 1];

	// On initialise les w en random
	for(int i = 0; i < inputSize + 1; ++i)
	{
		m->data[i] = (double) ((double) rand() / (RAND_MAX) +1) / 2;
	}
	return (int*) m;
}

// X : paramètres (coordonnées)
// Y : resultats (hauteur y)
// N nombre d'exemples (p65 :k = N)
// n nombre de paramètres
void LinearPerceptronRegression_Training(int* index, int size, int inputSize, double* inputInput, double* inputResult)
{
	// On récupère le modèle
	Model* m = (Model*) index;

	// ou inverse ?
	Eigen::MatrixXd X(size, inputSize + 1);
	Eigen::MatrixXd Y(size, 1);

	for(int x = 0; x < size; ++x)
	{
		X(x, 0) = m->data[0];
		for(int y = 0; y < inputSize; ++y)
		{
			X(x, y + 1) = inputInput[x*inputSize + y];
		}
		Y(x, 0) = inputResult[x];
	}

	Eigen::MatrixXd Xt = X.transpose();

	//Eigen::MatrixXd temp = (Xt * X);

	//Eigen::MatrixXd temp2 = temp.inverse();

	//Eigen::MatrixXd temp3 = temp2 * Xt;

	//Eigen::MatrixXd temp4 = temp3 * Y;

	Eigen::MatrixXd W = (((Xt * X).inverse()) * Xt) * Y;

	// Ca marche mais ca devrait pas
	//m->data[0] = W(0, 0);
	//for(int i = 0; i < inputSize; ++i)
	//{
	//	m->data[i + 1] = W(i, 0);
	//}

	// Ca marche pas mais ca devrait
	m->data[0] = W(0, 0);
	for(int i = 0; i < inputSize; ++i)
	{
		m->data[i + 1] = W(i + 1, 0);
	}
}

double LinearPerceptronRegression_Predict(int* index, int inputSize, double* input)
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

void LinearPerceptronRegression_Deletion(int* index)
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