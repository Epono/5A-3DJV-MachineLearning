#pragma once

// Simple neurone
struct Model
{
	// Numéro du neurone dans la couche si c'est un multi couches
	// Commence à 0
	int modelNumber;

	// Nombre de paramètres si c'est un multi couches
	int numberOfParameters;

	// Poids du neurone
	double* data;
};

// Couche de neurones
struct Layer
{
	// Numéro de couche
	// Commence à 0
	int layerNumber;

	// Nombre de paramètres (n + bias + 1 par couche)
	int numberOfModels;

	// Tableau de pointeurs sur des neurones
	Model** models;
};

// Perceptron multi couches
struct ModelMultiLayers
{
	// Nombre de couches
	int numberOfInternLayers;

	// Tableau de pointeurs sur les couches
	Layer** layers;
};

