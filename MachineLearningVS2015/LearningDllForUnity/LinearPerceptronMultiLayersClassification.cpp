#include <random>

#include "LinearPerceptronMultiLayersClassification.h"
#include "Model.h"

int* LinearPerceptronMultiLayersClassification_Creation(int inputSize)
{
	ModelMultiLayers* modelMultiLayers = new ModelMultiLayers();
	modelMultiLayers->numberOfLayers = 1;
	modelMultiLayers->layers = (Layer**) malloc(sizeof(Layer*) * modelMultiLayers->numberOfLayers);

	// On initialise chaque couche
	for(int i = 0; i < modelMultiLayers->numberOfLayers; ++i)
	{
		Layer* layer = new Layer();
		layer->layerNumber = i;
		// Le nombre de neurones c'est "Nombre de paramètres + 1 (biais) + numéro de la couche (+1 neurone par profondeur de couche)"
		layer->numberOfModels = inputSize + layer->layerNumber + 1;
		layer->models = (Model**) malloc(sizeof(Model*) * layer->numberOfModels);

		// On initialise chaque neurone
		for(int j = 0; j < layer->numberOfModels; ++j)
		{
			Model* model = new Model();
			model->modelNumber = j;
			model->numberOfParameters = layer->numberOfModels;
			// Pas sur pour l'initialisation
			model->x = 1;
			model->data = new double[model->numberOfParameters];

			// On initialise les poids des liaisons
			for(int k = 0; k < model->numberOfParameters; ++k)
			{
				model->data[k] = (double) ((double) rand() / (RAND_MAX) +1) / 2;
			}

			layer->models[j] = model;
		}

		modelMultiLayers->layers[i] = layer;
	}

	return (int*) modelMultiLayers;
}

void LinearPerceptronMultiLayersClassification_Training(int* index, int iterationsCount, int size, int inputSize, double* inputInput, double* inputResult)
{
	ModelMultiLayers* modelMultiLayers = (ModelMultiLayers*) index;

	for(int i = 1; i < modelMultiLayers->numberOfLayers; ++i)
	{
		Layer* layer = modelMultiLayers->layers[i];
		Layer* previousLayer = modelMultiLayers->layers[i-1];

		for(int j = 0; j < layer->numberOfModels; ++j)
		{
			Model* model = layer->models[j];
			double sum = 0;

			for(int k = 0; k < previousLayer->numberOfModels; ++k)
			{
				double previousX = previousLayer->models[k]->x;
				double w = layer->models[j]->data[k];
				sum += previousX * w;
			}

			model->x = tanh(sum);
		}
	}

	//for(i = 1; i < nNumLayers; i++)
	//{
	//	for(j = 0; j < pLayers[i].nNumNeurons; j++)
	//	{
	//		/* --- calcul de la somme pond�r�e en entr�e */
	//		double sum = 0.0;
	//		for(k = 0; k < pLayers[i - 1].nNumNeurons; k++)
	//		{
	//			double out = pLayers[i - 1].pNeurons[k].x;
	//			double w = pLayers[i].pNeurons[j].w[k];
	//			sum += w * out;
	//		}
	//		/* --- application de la fonction d'activation (sigmoid) */
	//		pLayers[i].pNeurons[j].x = 1.0 / (1.0 + exp(-dGain * sum));
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

	for(int i = 0; i < modelMultiLayers->numberOfLayers; ++i)
	{
		Layer* layer = modelMultiLayers->layers[i];

		for(int j = 0; j < layer->numberOfModels; ++j)
		{
			Model* model = layer->models[j];
			delete[] model->data;
		}
		delete[] layer->models;
	}
	delete[] modelMultiLayers->layers;
}
