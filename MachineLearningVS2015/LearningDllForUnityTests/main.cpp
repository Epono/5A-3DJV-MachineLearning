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

	getchar();
}