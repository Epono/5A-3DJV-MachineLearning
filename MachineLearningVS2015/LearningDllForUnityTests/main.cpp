#include <iostream>

#include "../LearningDllForUnity/LinearPerceptronClassification.h"
// LearningDllForUnity.lib

void main()
{
	int* ptr = LinearPerceptronClassification_Creation(2);

	double tableauBite[20][20];
	for(int x = 0; x < 20; ++x)
	{
		for(int y = 0; y < 20; ++y)
		{
			tableauBite[x][y] = 0;
		}
	}

	tableauBite[3][1] = 1;
	tableauBite[1][2] = 1;

	tableauBite[15][15] = -1;
	tableauBite[15][16] = -1;

	for(int x = 0; x < 20; ++x)
	{
		for(int y = 0; y < 20; ++y)
		{
			std::cout << (tableauBite[x][y] < 0 ? "" : " ") << tableauBite[x][y] << " ";
		}
		std::cout << std::endl;
	}

	std::cout << std::endl;
	std::cout << std::endl;
	std::cout << std::endl;
	std::cout << std::endl;

	double inputInput[]{3, 1, 1, 2, 15, 15, 15, 16};
	double inputResult[]{1, 1, -1, -1};

	LinearPerceptronClassification_Training(ptr, 1000, 4, 2, inputInput, inputResult);

	for(int x = 0; x < 20; ++x)
	{
		for(int y = 0; y < 20; ++y)
		{
			double bite[]{x, y};
			double result = LinearPerceptronClassification_Predict(ptr, 2, bite);
			std::cout << (result < 0 ? "" : " ") << result << " ";
		}
		std::cout << std::endl;
	}

	getchar();
}