import clr
import UnityEngine as ue

random_sequence = ue.Object.FindObjectOfType(clr.RandomSequence)

N = 1000

m = 10000
M = 4566

revert_m = 0.0001

Z0 = 4

values = []

expectation = 0
select_middle = 0
var = 0
select_var = 0

intervals = []
hit_intervals = []
relative_hit_intervals = []

for i in range(1, 11):
    intervals.append(m * (i / 10))
    hit_intervals.append(0)
 
def lkm():
  global x
  global select_middle
  global select_var
  x = (M*x) % m # Zi+1 = (a*Zi ) (mod m)

  select_middle += x
  select_var += revert_m * ((x - expectation) ** 2)

  for i in range(0, 10):
      if x <= intervals[i]:
          hit_intervals[i] += 1
          break
  
  return int(x)

for i in range(0,m+1):
    expectation += i * revert_m

x=Z0
for i in range(0,N):
    value = lkm()
    random_sequence.Enqueue(value)
    values.append(value)
