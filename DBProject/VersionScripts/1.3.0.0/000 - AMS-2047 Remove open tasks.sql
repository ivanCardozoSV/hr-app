UPDATE tasks.Tasks
SET RecordStatus = 2
WHERE RecordStatus = 0
AND ParentTaskId IS NOT NULL