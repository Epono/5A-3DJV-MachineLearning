#pragma once

// Simple neurone
struct Model
{
	// Poids du neurone
	double* data;

	/////////////////////////////////////////////////////////////////////// Utilis� que pour le multi couche
	// Num�ro du neurone dans la couche
	// Commence � 0
	int modelNumber;

	// Nombre de param�tres si
	int numberOfParameters;

	// Valeur de sortie effective
	int x;
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

