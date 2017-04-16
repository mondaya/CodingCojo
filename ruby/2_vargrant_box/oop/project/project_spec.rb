require_relative 'project' # include our Project class in our spec file
RSpec.describe Project do  
  before(:each) do 
    @project1 = Project.new('Project 1', 'description 1') # create a new project and make sure we can set the name attribute
    @project2 = Project.new('Project 2', 'description 2')
  end
  it 'has a getter and setter for name attribute' do
    @project1.name = "Changed Name" # this line would fail if our class did not have a setter method
    expect(@project1.name).to eq("Changed Name") # this line would fail if we did not have a getter or if it did not change the name successfully in the previous line.
  end 

  it 'has a method elevator_pitch to explain name and description' do
    expect(@project1.elevator_pitch).to eq("Project 1, description 1")
    expect(@project2.elevator_pitch).to eq("Project 2, description 2")
  end

   it 'has a getter and setter for onwer attribute' do
    @project1 = Project.new('Project 1', 'description 1') # create a new project and make sure we can set the owner attribute
    @project1.owner = "Big Papi" # this line would fail if our class did not have a setter method
    expect(@project1.owner).to eq("Big Papi") # this line would fail if we did not have a getter or if it did not change the owner successfully in the previous line.
  end 

  it 'has a getter and setter for onwer tasks' do
    @project1 = Project.new('Project 1', 'description 1') # create a new project and make sure we can set the task attribute
    @project1.tasks = ["run","jump", "skip"] # this line would fail if our class did not have a setter method
    expect(@project1.tasks).to eq(["run","jump", "skip"] ) # this line would fail if we did not have a getter or if it did not change the tasks successfully in the previous line.
  end 


  it 'prints tasks to standrd out' do
    @project1 = Project.new('Project 1', 'description 1') # create a new project and make sure we can set the task attribute
    @project1.tasks =  [] 
    @project1.tasks = ["run","jump", "skip"] # this line would fail if our class did not have a setter method
    #@project1.print_tasks
    expect{@project1.print_tasks}.to output(/run*jump*skip/).to_stdout # this line would fail if we did not have a getter or if it did not change the tasks successfully in the previous line.
  end 


   it 'has a method elevator_pitch to explain the name and description' do
    expect(@project1.elevator_pitch).to eq("Project 1, description 1")
    expect(@project2.elevator_pitch).to eq("Project 2, description 2")
  end 

   it 'has a method add_tasks that pushes a single task to the tasks attribute and a tasks method that returns all the task' do
      1.upto(4) { |n| @project1.add_tasks("Task # #{n}") }
      expect(@project1.tasks).to eq(["Task # 1", "Task # 2", "Task # 3", "Task # 4"])
    end

    it 'has a method print_taks that prints every task in the project' do
      1.upto(2) { |n| @project1.add_tasks("Task # #{n}") }
      expect{ @project1.print_tasks }.to output(/Task # 1*Task # 2/).to_stdout
    end


    it "has a getter and setter for name attribute" do
      project = Project.new
      project.name = "Name"
      expect(project.name).to eq("Name")
    end
    it "has a getter and setter for the description attribute" do
      project = Project.new
      project.description = "Description"
      expect(project.description).to eq("Description")
    end
    it 'has a method elevator_pitch to explain name and description' do
      project = Project.new
      project.name = "Name"
      project.description = "Description"
      expect(project.elevator_pitch).to eq("Name, Description")
    end


  
end