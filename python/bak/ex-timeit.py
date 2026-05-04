import time
import timeit

# Однострочное выражение
execution_time = timeit.timeit('sum(range(1000000))', number=100)
print(f"Среднее время: {execution_time / 100:.6f} секунд")

tm1start = time.time()
# Для блока кода
code_block = '''
result = 0
for i in range(1000):
    result += i**2
'''
tm1end = time.time()
print(f"Время выполнения: {tm1end - tm1start:.6f} секунд")

time = timeit.timeit(stmt=code_block, number=1)
print(f"Время: {time:.6f} секунд")