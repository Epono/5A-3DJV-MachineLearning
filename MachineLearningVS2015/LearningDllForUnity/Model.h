#pragma once

// Simple neurone
struct Model
{
	// Num�ro du neurone dans la couche si c'est un multi couches
	// Commence � 0
	int modelNumber;

	// Nombre de param�tres si c'est un multi couches
	int numberOfParameters;

	// Poids du neurone
	double* data;

	//Delta du neurone
	double delta;

	//Output du neurone
	double x;
};

// Couche de neurones
struct Layer
{
	// Num�ro de couche
	// Commence � 0
	int layerNumber;

	// Nombre de param�tres (n + bias + 1 par couche)
	int numberOfModels;

	// Tableau de pointeurs sur des neurones
	Model** models;
};

// Perceptron multi couches
struct ModelMultiLayers
{
	// Nombre de couches
	int numberOfLayers;

	// Tableau de pointeurs sur les couches
	Layer** layers;
};

