# Databricks notebook source
# MAGIC %fs ls /FileStore/tables/t4ismsl81493682860925/final_data_set.csv

# COMMAND ----------

houseDataSetDf = sqlContext.read.format("csv")\
  .option("header","true")\
  .option("inferSchema", "true")\
  .option("delimiter", ',') \
  .load("/FileStore/tables/t4ismsl81493682860925/final_data_set.csv")

display(houseDataSetDf)

# COMMAND ----------

houseDataSetDf.describe().toPandas().transpose()

# COMMAND ----------

import pprint
from pyspark.mllib.regression import LabeledPoint

# Create an instance of pretty print for output formatting
pp = pprint.PrettyPrinter(indent=4)

# Create a list of values to be used by the label point
def getLabelPointValues(row):
  headers = ["total_approximate_size", "total_appraisal_value", "zestimate_amount", 
             "valuation_range_high", "valuation_range_low", "bedrooms", "bathrooms", "finished_sqft"]
  values = []
  for header in headers:
    values.append(float(row[header]))
  return values

def removeRowsThatContainNull(row):
  headers = ["total_approximate_size", "total_appraisal_value", "zestimate_amount", 
             "valuation_range_high", "valuation_range_low", "bedrooms", "bathrooms", "finished_sqft"]  
  for header in headers:
    if str(row[header]) == "NULL":
      return False
  return True

# Filter out any rows that contain NULL as a value
houseDataSetFilteredRdd = houseDataSetDf.rdd.filter(lambda row: removeRowsThatContainNull(row))

# Load the data iinto an rdd of label points 
houseDataSetLabelPoints = houseDataSetFilteredRdd.map(lambda row: LabeledPoint(row["total_market_share"], getLabelPointValues(row)))

print(houseDataSetLabelPoints.count())

# Print out the label points generated
pp.pprint(houseDataSetLabelPoints.collect())

# COMMAND ----------

from pyspark.mllib.regression import LabeledPoint, LinearRegressionWithSGD, LinearRegressionModel

# Split the House Data Set Label Points into training and testing sets 
(trainingData, testData) = houseDataSetLabelPoints.randomSplit([0.7, 0.3])
print("Training Data Set Count =" + str(trainingData.count()))
print("Testing Data Set Count = " + str(testData.count()))

# Build the model
model = LinearRegressionWithSGD.train(trainingData, iterations=100, step=0.00000001)

# Evaluate model on test instances
predictions = model.predict(testData.map(lambda x: x.features))
labelsAndPredictions = testData.map(lambda lp: lp.label).zip(predictions)

# Print out mean squared error
testMSE = labelsAndPredictions.map(lambda (v, p): (v - p) * (v - p)).sum() / float(testData.count())
print('Mean Squared Error = ' + str(testMSE))
