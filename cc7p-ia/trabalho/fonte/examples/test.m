training = [mvnrnd([ 1  1],   eye(2), 100); ...
            mvnrnd([-1 -1], 2*eye(2), 100)];
group = [repmat(1,100,1); repmat(2,100,1)];
gscatter(training(:,1),training(:,2),group,'rb','+x');
legend('Vermelho', 'Azul');
hold on;

sample = unifrnd(-5, 5, 100, 2);
% Classify the sample using the nearest neighbor classification
c = knnclassify(sample, training, group, 3);
gscatter(sample(:,1),sample(:,2),c,'mc'); hold on;
legend('Training group 1','Training group 2', ...
       'Data in group 1','Data in group 2');
hold off; 

%%%%%%%%%%%%%%%%

%# image size
sz = [25,42];

%# training images
numTrain = 200;
trainData = zeros(numTrain,prod(sz));
for i=1:numTrain
    img = imread( sprintf('train/image_%03d.jpg',i) );
    trainData(i,:) = img(:);
end

%# testing images
numTest = 200;
testData = zeros(numTest,prod(sz));
for i=1:numTest
    img = imread( sprintf('test/image_%03d.jpg',i) );
    testData(i,:) = img(:);
end

%# target class (I'm just using random values. Load your actual values instead)
trainClass = randi([1 5], [numTrain 1]);
testClass = randi([1 5], [numTest 1]);

%# compute pairwise distances between each test instance vs. all training data
D = pdist2(testData, trainData, 'euclidean');
[D,idx] = sort(D, 2, 'ascend');

%# K nearest neighbors
K = 5;
D = D(:,1:K);
idx = idx(:,1:K);

%# majority vote
prediction = mode(trainClass(idx),2);

%# performance (confusion matrix and classification error)
C = confusionmat(testClass, prediction);
err = sum(C(:)) - sum(diag(C))