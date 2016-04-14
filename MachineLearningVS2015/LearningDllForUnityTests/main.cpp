#include <iostream>

#include "../LearningDllForUnity/LinearPerceptronClassification.h"
#include "../LearningDllForUnity/LinearPerceptronRegression.h"
#include "../LearningDllForUnity/LinearPerceptronMultiLayersClassification.h"

void TestLinearPerceptronClassification()
{
	//int* ptr = LinearPerceptronClassification_Creation(2);
	int* ptr = LinearPerceptronMultiLayersClassification_Creation(2, new int[2]{ 2,1 }, 2);

	double tableauBite[20][20];
	for(int x = 0; x < 20; ++x)
	{
		for(int y = 0; y < 20; ++y)
		{
			tableauBite[x][y] = 0;
		}
	}

	tableauBite[0][19] = 1;
	//tableauBite[1][2] = -1;

	tableauBite[19][0] = -1;
	//tableauBite[15][16] = 1;

	double inputInput[]{0, 19, 19, 0};
	double inputResult[]{1, -1};

	for(int y = 19; y >= 0; --y)
	{
		for(int x = 0; x < 20; ++x)
		{
			std::cout << (tableauBite[x][y] < 0 ? "" : " ") << tableauBite[x][y] << " ";
		}
		std::cout << std::endl;
	}

	std::cout << std::endl;
	std::cout << std::endl;
	std::cout << std::endl;
	std::cout << std::endl;

	LinearPerceptronClassification_Training(ptr, 10000, 2, 2, inputInput, inputResult);

	for(int y = 19; y >= 0; --y)
	{
		for(int x = 0; x < 20; ++x)
		{
			double bite[]{x, y};
			double result = LinearPerceptronClassification_Predict(ptr, 2, bite);
			std::cout << (result < 0 ? "" : " ") << result << " ";
		}
		std::cout << std::endl;
	}
}

void TestLinearPerceptronMultiLayerClassification()
{
	int* ptr = LinearPerceptronMultiLayersClassification_Creation(2, new int[2]{ 2,1 }, 2);

	double tableauBite[20][20];
	for (int x = 0; x < 20; ++x)
	{
		for (int y = 0; y < 20; ++y)
		{
			tableauBite[x][y] = 0;
		}
	}

	tableauBite[5][9] = 1;

	tableauBite[13][16] = -1;
	tableauBite[17][13] = -1;

	double inputInput[]{ 5/20.0, 9 / 20.0, 13 / 20.0, 16 / 20.0, 17 / 20.0, 13 / 20.0 };
	double inputResult[]{ 1, -1, -1 };

	for (int y = 19; y >= 0; --y)
	{
		for (int x = 0; x < 20; ++x)
		{
			std::cout << (tableauBite[x][y] < 0 ? "" : " ") << tableauBite[x][y] << " ";
		}
		std::cout << std::endl;
	}

	std::cout << std::endl;
	std::cout << std::endl;
	std::cout << std::endl;
	std::cout << std::endl;

	LinearPerceptronMultiLayersClassification_Training(ptr, 1000, 3, 2, inputInput, inputResult);

	for (int y = 19; y >= 0; --y)
	{
		for (int x = 0; x < 20; ++x)
		{
			double tab[] = { x,y };
			double result = LinearPerceptronMultiLayersClassification_Predict(ptr, 1, 0, tab, 2, 0);
			std::cout << (result < 0 ? "" : " ") << result << " ";
		}
		std::cout << std::endl;
	}
}

void TestLinearPerceptronRegression()
{
	int* ptr = LinearPerceptronRegression_Creation(2);

	double tableauBite[20][20];
	for(int x = 0; x < 20; ++x)
	{
		for(int y = 0; y < 20; ++y)
		{
			tableauBite[x][y] = 0;
		}
	}

	tableauBite[2][2] = 1;
	tableauBite[3][3] = 1;
	tableauBite[15][16] = -1;

	double inputInput[]{2, 2, 3, 3, 15, 16};
	double inputResult[]{1, 1, -1};

	for(int y = 19; y >= 0; --y)
	{
		for(int x = 0; x < 20; ++x)
		{
			std::cout << (tableauBite[x][y] < 0 ? "" : " ") << tableauBite[x][y] << " ";
		}
		std::cout << std::endl;
	}

	std::cout << std::endl;
	std::cout << std::endl;
	std::cout << std::endl;
	std::cout << std::endl;

	LinearPerceptronRegression_Training(ptr, 3, 2, inputInput, inputResult);

	for(int y = 19; y >= 0; --y)
	{
		for(int x = 0; x < 20; ++x)
		{
			double bite[]{x/20.0, y/20.0};
			double result = LinearPerceptronRegression_Predict(ptr, 2, bite);
			std::cout << (result < 0 ? "" : " ") << result << " ";
		}
		std::cout << std::endl;
	}
}

void main()
{
	//TestLinearPerceptronClassification();
	//TestLinearPerceptronRegression();
	TestLinearPerceptronMultiLayerClassification();

	getchar();
}