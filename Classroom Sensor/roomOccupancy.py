import numpy as np
data = np.loadtxt("log.txt")

X = data[:, :-1] # select all the rows in the data object and all the columns except the last one
y = data[:, -1] # select all the rows in the last column of the data object

#check out the first few entries to prove to yourself you have the right data:
print(X[:10, :]) 
print(y[:10])

#shuffle up the rows, so that when you section your data up you get variation in each section
from sklearn.utils import shuffle 
X, y = shuffle(X, y, random_state=1)

#Scale the data using the StandardScaler class from scikit-learn.
from sklearn import preprocessing
X_scaled = preprocessing.scale(X)

#Split the data into a training set and test set (test set size should be 33%)
from sklearn.cross_validation import train_test_split
X_train, X_test, y_train, y_test = train_test_split(X_scaled, y, test_size=0.33, random_state=42)

#create and train model
from sklearn import linear_model
model = linear_model.LinearRegression()
model.fit(X_train, y_train);

#check accuracy of model against test set
print(model.score(X_test, y_test))
