
module AccountType
    CHECKING = 1
    SAVINGS = 2
end

class BankAccount
  
  attr_reader:bank_acc_number,:balance

  @@bank_accounts  = 0
  def initialize
      @@bank_accounts += 1
      @balance = {:checking => 0.0, :savings => 0.0}
      @interest_rate = 0.01
      @bank_acc_number =  generate_acc_number
  end



  def get_account_number
    @bank_acc_number 
    self 
  end

  private
  def generate_acc_number
      @bank_acc_number  =  rand(100000000..999999999)
  end
  
  public

  def checking_balance
      @balance[:checking]      
  end

  def saving__balance
      @balance[:savings]      
  end

  def self.number_of_accounts
    @@bank_accounts 
  end

   def deposit amount, account_type
       puts "depositing #{amount}"
       if (account_type ==  AccountType::SAVINGS) && (amount > 0)
                @balance[:savings]  +=  amount    
       elsif (account_type ==  AccountType::CHECKING) && (amount > 0)
                @balance[:checking]  +=  amount 
       end    
  end

  def withdraw amount, account_type
       puts "withdrawing #{amount}"
       if (account_type ==  AccountType::SAVINGS) && (amount <=  balance[:savings])
                @balance[:savings]  -=  amount 
                  
       elsif (account_type ==  AccountType::CHECKING) && (amount <= balance[:checking])
                @balance[:checking]  -=  amount 
       else 
            raise InsufficientFunds, "Insufficient balance. reduce your amount of #{amount}" if (amount > @balance[:checking]) &&  (account_type ==  AccountType::CHECKING)
            raise InsufficientFunds, "Insufficient balance. reduce your amount of #{amount}" if (amount > @balance[:savings]) &&  (account_type ==  AccountType::SAVINGS)
            raise InsufficientFunds, "Invalid account type" unless ((account_type ==  AccountType::CHECKING) ||  (account_type == AccountType::SAVINGS))
       end    
  end


   def account_balances
       puts "Savings: #{@balance[:savings]}"
       puts "Checking: #{@balance[:checking]}"  
       puts "Your total balance: #{@balance[:savings] + @balance[:checking] }"    
  end

  def num_account_types
       @balance.count     
  end

   def account_information
       puts "Account Number: #{@bank_acc_number}"
       puts "Total Amount: #{@balance[:savings] + @balance[:checking] }"
       puts "Savings: #{@balance[:savings]}"
       puts "Checking: #{@balance[:checking]}"  
       puts "Interest rate: #{@interest_rate}"    
  end 


  # your code here
end



class InsufficientFunds < StandardError 

end




=begin
user1 =  BankAccount.new
user2 = BankAccount.new

puts user2.number_of_accounts
puts user1.checking_balance

user1.deposit(200, AccountType::SAVINGS)
puts user1.saving__balance

user1.deposit(200, AccountType::CHECKING)
puts user1.checking_balance


user1.withdraw(60, AccountType::SAVINGS)
puts user1.saving__balance

user1.withdraw(30, AccountType::CHECKING)
puts user1.checking_balance

user2.deposit(200, AccountType::SAVINGS)
puts user2.saving__balance

user2.deposit(200, AccountType::CHECKING)
puts user2.checking_balance


user2.withdraw(50, AccountType::SAVINGS)
puts user2.saving__balance

user2.withdraw(30, AccountType::CHECKING)
puts user2.checking_balance

user2.withdraw(250, AccountType::CHECKING)
puts user2.checking_balance

user1.account_balances
user2.account_balances

puts user1.num_account_types
puts user2.num_account_types

user1.account_information
user2.account_information
=end

