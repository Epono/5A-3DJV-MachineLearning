#include <iostream>

#include "../LearningDllForUnity/LinearPerceptronClassification.h"

void main()
{
	int* ptr = LinearPerceptronClassification_Creation(1);
	double wtf = LinearPerceptronClassification_Training(ptr, 0);

	std::cout << wtf << std::endl;

	getchar();
}