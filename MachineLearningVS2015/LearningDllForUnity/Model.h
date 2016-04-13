#pragma once

// Simple neurone
struct Model
{
	// Poids du neurone
	double* data;

	/////////////////////////////////////////////////////////////////////// Utilisé que pour le multi couche
	// Numéro du neurone dans la couche
	// Commence à 0
	int modelNumber;

	// Nombre de paramètres si
	int numberOfParameters;

	// Valeur de sortie effective
	int x;
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
	int numberOfLayers;

	// Tableau de pointeurs sur les couches
	Layer** layers;
};

